using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameBoardManager : MonoBehaviour
{
    public static GameBoardManager Instance { get; private set; }

    public static UnityEvent<GameState> OnGameStateChanged = new UnityEvent<GameState>();


    [SerializeField]
    private Sprite[] gameCardsSprites;

    [SerializeField]
    private Transform gameBoardParent;

    [SerializeField]
    private GameCard gameCardsPrefab;

    [SerializeField]
    private GameObject boardRowPrefab;

    [Header("times")]
    [SerializeField]
    private float timeBeforeGameStarts = 2f;
    [SerializeField]
    private float timeForShowCards = 1f;

    private GameState currentGameState = GameState.Idle;

    private int matchedCardsCount = 0;

    private List<GameCard> flippedCards;

    public GameState CurrentGameState
    {
        private set
        {
            if (currentGameState == value) return;
            currentGameState = value;

            OnGameStateChanged.Invoke(currentGameState);
        }

        get
        {
            return currentGameState;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PopulateBoard();

        StartCoroutine(StartGameCoroutine());

        GameCard.CardFlipped.AddListener(HandleCardFlipped);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartGameCoroutine()
    {
        yield return null;
        CurrentGameState = GameState.GameStart;
        yield return new WaitForSeconds(timeBeforeGameStarts);
        CurrentGameState = GameState.GameInProgress;
    }

    private void HandleCardFlipped(GameCard flippedCard)
    {
        if (flippedCards == null)
            flippedCards = new List<GameCard>();
        flippedCards.Add(flippedCard);

        if (flippedCards.Count < 2)
            return;

        StartCoroutine(ShowingFlippedCardsState());
    }

    IEnumerator ShowingFlippedCardsState()
    {
        CurrentGameState = GameState.ShowingCards;
        yield return new WaitForSeconds(timeForShowCards);

        // check if the cards match
        if (flippedCards[0].CardSprite == flippedCards[1].CardSprite)
        {
            // cards match
            CurrentGameState = GameState.CardsMatched;
            matchedCardsCount += 2;

            // check if the game is over
            int totalCardsCount = GameData.Instance.GameSizeX * GameData.Instance.GameSizeY;
            if(totalCardsCount % 2 != 0)
            {
                totalCardsCount--;
            }
            if (matchedCardsCount >= totalCardsCount)
            {
                CurrentGameState = GameState.GameOver;
            }
            else
            {
                flippedCards = null;
                CurrentGameState = GameState.GameInProgress;
            }
        }
        else
        {
            flippedCards = null;
            CurrentGameState = GameState.GameInProgress;
        }
    }

    private void PopulateBoard()
    {
        int boardSizeX = GameData.Instance.GameSizeX;
        int boardSizeY = GameData.Instance.GameSizeY;
        int totalCardsCount = boardSizeX * boardSizeY;

        // remove the last card if the total number of cards is odd
        if (totalCardsCount % 2 != 0)
        {
            totalCardsCount--;
        }

        // choose random cards.
        List<Sprite> selectedCards = new List<Sprite>();
        for (int i = 0; i < totalCardsCount; i += 2)
        {
            int randomIndex = Random.Range(0, gameCardsSprites.Length);
            selectedCards.Add(gameCardsSprites[randomIndex]);
            selectedCards.Add(gameCardsSprites[randomIndex]);
        }

        for (int i = 0; i < boardSizeY; i++)
        {
            // instantiate a row prefab
            GameObject row = Instantiate(boardRowPrefab, gameBoardParent);
            for (int j = 0; j < boardSizeX; j++)
            {
                if (selectedCards.Count == 0)
                {
                    break;
                }

                // get a random card 
                int randomIndex = Random.Range(0, selectedCards.Count);

                // instantiate the card
                GameCard card = Instantiate(gameCardsPrefab, row.transform);
                card.Initialize(selectedCards[randomIndex]);

                // remove the card from the list
                selectedCards.RemoveAt(randomIndex);
            }
        }

    }
}

public enum GameState
{
    Idle,
    GameStart,
    GameInProgress,
    ShowingCards,
    CardsMatched,
    GameOver
}