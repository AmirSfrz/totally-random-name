using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public UnityEvent<int> OnScoreChanged = new UnityEvent<int>();
    public UnityEvent<int> OnComboChanged = new UnityEvent<int>();


    [SerializeField]
    private int scorePerCardsMatch = 2;

    [SerializeField]
    private float comboMaxTime = 5f;

    private int currentScore = 0;

    private int currentCombo = 0;

    private float currentComboTimer = 0f;

    public float CurrentComboTimer => currentComboTimer;

    public float ComboMaxTime => comboMaxTime;

    public int CurrentScore
    {
        private set
        {
            currentScore = value;
            OnScoreChanged.Invoke(CurrentScore);
        }
        get
        {
            return currentScore;
        }
    }
    public int CurrentCombo
    {
        private set
        {
            currentCombo = value;
            OnComboChanged.Invoke(CurrentCombo);
        }
        get
        {
            return currentCombo;
        }
    }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameBoardManager.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameState newState)
    {
        if (newState == GameState.CardsMatched)
        {
            AddCombo();
        }
        else if (newState == GameState.GameOver)
        {
            SaveOrLoadManager.instance.PlayerTotalScore += CurrentScore;
        }
    }

    public void AddCombo()
    {
        CurrentCombo += 1;

        CurrentScore += scorePerCardsMatch * CurrentCombo;

        currentComboTimer = comboMaxTime;
    }

    private void Update()
    {
        if (currentComboTimer > 0f)
        {
            currentComboTimer -= Time.deltaTime;
            if (currentComboTimer <= 0f)
            {
                CurrentCombo = 0;
                currentComboTimer = 0f;
            }
        }
    }
}
