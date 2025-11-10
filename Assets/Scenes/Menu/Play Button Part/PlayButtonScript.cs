using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{

    public void OnClick()
    {
        SceneManagement.instance.SwitchScene(SceneName.Game);
    }
}
