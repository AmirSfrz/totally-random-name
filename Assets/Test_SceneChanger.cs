using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SceneChanger : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManagement.instance.SwitchScene(SceneName.Menu);
    }

    public void GoToGame()
    {
        SceneManagement.instance.SwitchScene(SceneName.Game);
    }
}
