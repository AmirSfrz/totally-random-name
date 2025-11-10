using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSizeInputField : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;

    [SerializeField]
    private int minGameSize = 2;

    [SerializeField]
    private int maxGameSize = 8;

    [SerializeField]
    private GameSizeType gameSizeType;

    private void Start()
    {
        inputField.onEndEdit.AddListener(ValidateInput);

        // Initialize the input field with current game size
        if (gameSizeType == GameSizeType.X)
        {
            inputField.text = GameData.Instance.GameSizeX.ToString();
        }
        else if (gameSizeType == GameSizeType.Y)
        {
            inputField.text = GameData.Instance.GameSizeY.ToString();
        }
    }

    private void ValidateInput(string input)
    {
        int gameSize;
        if (int.TryParse(input, out gameSize))
        {
            gameSize = Mathf.Clamp(gameSize, minGameSize, maxGameSize); // Assuming game size should be between 3 and 10
        }
        else
        {
            gameSize = 3; // default value
        }


        inputField.text = gameSize.ToString();

        // set the game data
        if (gameSizeType == GameSizeType.X)
        {
            GameData.Instance.SetGameSize(gameSize, GameData.Instance.GameSizeY);
        }
        else if (gameSizeType == GameSizeType.Y)
        {
            GameData.Instance.SetGameSize(GameData.Instance.GameSizeX, gameSize);
        }

    }
}

public enum GameSizeType
{
    X,
    Y
}