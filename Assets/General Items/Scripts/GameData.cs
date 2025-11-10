using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    [SerializeField]
    private int gameSizeX = 3;

    [SerializeField]
    private int gameSizeY = 3;

    
    // Getters
    public int GameSizeX => gameSizeX;
    public int GameSizeY => gameSizeY;

    public Sprite[] avatars;


    // functions
    private void Awake()
    {
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

    public void SetGameSize(int x, int y)
    {
        gameSizeX = x;
        gameSizeY = y;
    }
}
