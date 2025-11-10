using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileScoreTxt : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerScoreTxt;

    private void Awake()
    {
        if (playerScoreTxt == null)
        {
            playerScoreTxt = GetComponent<TMP_Text>();
        }
    }

    private void Start()
    {
        SetPlayerScore(SaveOrLoadManager.instance.PlayerTotalScore);

        // set the event
        SaveOrLoadManager.instance.OnPlayerScoreUpdated.AddListener(SetPlayerScore);
    }

    private void SetPlayerScore(int playerTotalScore)
    {
        playerScoreTxt.text = playerTotalScore + "";
    }
}
