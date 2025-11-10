using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileName : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerNameTxt;

    private void Awake()
    {
        if (playerNameTxt == null)
        {
            playerNameTxt = GetComponent<TMP_Text>();
        }
    }

    private void Start()
    {
        SetPlayerName(SaveOrLoadManager.instance.PlayerName);

        // set the event
        SaveOrLoadManager.instance.OnPlayerNameUpdated.AddListener(SetPlayerName);
    }

    private void SetPlayerName(string playerName)
    {
        playerNameTxt.text = playerName;
    }
}
