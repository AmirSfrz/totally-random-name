using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public void Clicked()
    {
        SceneManagement.instance.SwitchScene(SceneName.Menu);
    }
}
