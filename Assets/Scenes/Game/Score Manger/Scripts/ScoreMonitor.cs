using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMonitor : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreNumberText;

    [SerializeField]
    private Image comboBarImage;

    [SerializeField]
    private TMP_Text comboNumberText;

    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged.AddListener(UpdateScoreDisplay);

        ScoreManager.Instance.OnComboChanged.AddListener(UpdateComboDisplay);

        UpdateScoreDisplay(ScoreManager.Instance.CurrentScore);
        UpdateComboDisplay(ScoreManager.Instance.CurrentCombo);
        comboBarImage.gameObject.SetActive(false);
    }

    private void UpdateScoreDisplay(int score)
    {
        scoreNumberText.text = score.ToString();
    }

    private void UpdateComboDisplay(int combo)
    {
        if (combo == 0)
        {
            comboBarImage.gameObject.SetActive(false);
            return;
        }


        comboBarImage.gameObject.SetActive(true);

        comboNumberText.text = (combo + 1).ToString();
    }

    private void Update()
    {
        comboBarImage.fillAmount = ScoreManager.Instance.CurrentComboTimer / ScoreManager.Instance.ComboMaxTime;
    }
}
