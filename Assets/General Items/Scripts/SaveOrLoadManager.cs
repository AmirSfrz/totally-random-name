using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveOrLoadManager : MonoBehaviour
{
    public static SaveOrLoadManager instance;

    private void Awake()
    {
        // handlingsingleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Tags for PlayerPrefs
    private const string PLAYER_TOTAL_SCORE_TAG = "PlayerTotalScore";
    private const string PLAYER_AVATAR_TAG = "PlayerAvatarTag";
    private const string PLAYER_NAME_TAG = "PlayerNameTag";


    // values loaded in cache
    private int _playerTotalScore = -1;

    private int _playerAvatarIndex = -1;

    private string _playerName = null;

    // Events (for the ones that are needed)

    public UnityEvent<int> OnPlayerAvatarUpdated = new();

    public UnityEvent<string> OnPlayerNameUpdated = new();

    public UnityEvent<int> OnPlayerScoreUpdated = new();

    // setters and getters
    public int PlayerTotalScore
    {
        get { return _playerTotalScore != -1 ? _playerTotalScore : PlayerPrefs.GetInt(PLAYER_TOTAL_SCORE_TAG, 0); }
        set
        {
            // return if the value is the same with the cached data
            if (_playerTotalScore == value) return;

            _playerTotalScore = value;
            PlayerPrefs.SetInt(PLAYER_TOTAL_SCORE_TAG, _playerTotalScore);

            OnPlayerScoreUpdated.Invoke(_playerTotalScore);
        }
    }

    public int PlayerAvatarIndex
    {
        get { return _playerAvatarIndex != -1 ? _playerAvatarIndex : PlayerPrefs.GetInt(PLAYER_AVATAR_TAG, 0); }
        set
        {
            // return if the value is the same with the cached data
            if (_playerAvatarIndex == value) return;

            _playerAvatarIndex = value;
            PlayerPrefs.SetInt(PLAYER_AVATAR_TAG, _playerAvatarIndex);

            OnPlayerAvatarUpdated.Invoke(_playerAvatarIndex);
        }
    }

    public string PlayerName
    {
        get { return _playerName != null ? _playerName : PlayerPrefs.GetString(PLAYER_NAME_TAG, "Player"); }
        set
        {
            // return if the value is the same with the cached data
            if (_playerName == value) return;

            _playerName = value;
            PlayerPrefs.SetString(PLAYER_NAME_TAG, _playerName);

            OnPlayerNameUpdated.Invoke(_playerName);
        }
    }

}
