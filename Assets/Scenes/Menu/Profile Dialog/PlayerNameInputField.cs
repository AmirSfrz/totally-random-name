using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameInputField : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField playerNameInputField;

    private void Awake()
    {
        if (playerNameInputField == null)
        {
            playerNameInputField = GetComponent<TMP_InputField>();
        }
    }

    private void OnEnable()
    {
        SetPlayerName(SaveOrLoadManager.instance.PlayerName);
    }

    private void SetPlayerName(string playerName)
    {
        playerNameInputField.text = playerName;
    }

    public void OnPlayerNameInputFieldValueChanged()
    {
        //check if the value is not empty
        if (string.IsNullOrEmpty(playerNameInputField.text))
        {
            return;
        }

        //setting the name
        SaveOrLoadManager.instance.PlayerName = playerNameInputField.text;
    }
}
