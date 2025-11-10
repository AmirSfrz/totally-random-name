using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOrLoadManager : MonoBehaviour
{
    public static SaveOrLoadManager instance;

    // Tags for PlayerPrefs
    private const string PLAYER_TOTAL_SCORE_TAG = "PlayerTotalScore";


    // values loaded in cache
    private int _playerTotalScore = -1;


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
        }
    }

}
