using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameCard : MonoBehaviour
{
    public static UnityEvent<GameCard> CardFlipped = new UnityEvent<GameCard>();

    private Sprite cardSprite;

    public Sprite CardSprite => cardSprite;

    [SerializeField]
    private Image cardFrontImage;

    [SerializeField]
    private Animator Animator;

    private bool isFlipped = false;

    private bool cardMatched = false;

    private void Start()
    {
        GameBoardManager.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    public void Initialize(Sprite cardSprite)
    {
        this.cardSprite = cardSprite;
        cardFrontImage.sprite = cardSprite;
    }

    private void ShowFront(bool callEvent = false)
    {
        Animator.SetTrigger("FlipToFront");
        isFlipped = true;

        if (callEvent)
            CardFlipped.Invoke(this);
    }

    private void ShowBack()
    {
        Animator.SetTrigger("FlipToBack");
        isFlipped = false;
    }

    public void Clicked()
    {
        if (isFlipped || GameBoardManager.Instance.CurrentGameState != GameState.GameInProgress)
            return;

        ShowFront(true);
    }

    private void HandleGameStateChanged(GameState newState)
    {
        if (cardMatched)
            return;
        switch (newState)
        {
            case GameState.Idle:
                break;
            case GameState.GameStart:
                ShowFront();
                break;
            case GameState.GameInProgress:
                if (isFlipped)
                    ShowBack();
                break;
            case GameState.ShowingCards:
                break;
            case GameState.CardsMatched:
                if (isFlipped)
                {
                    cardMatched = true;
                    cardFrontImage.gameObject.SetActive(false);
                }
                break;
            case GameState.GameOver:
                break;
            default:
                break;
        }
    }
}
