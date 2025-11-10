using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneManagement : MonoBehaviour
{

    //statics
    public static SceneManagement instance;

    //                      duration
    public static UnityEvent<float> OnSceneGoingToChange = new UnityEvent<float>();


    // variables
    [SerializeField]
    private float sceneChangeDuration = 1f;


    [SerializeField]
    private List<SceneData> scenesData = new List<SceneData>();

    private bool changeSceneInProgress = false;


    //getters
    public float SceneChangeDuration { get { return sceneChangeDuration; } }


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


    public void SwitchScene(SceneName sceneName)
    {
        if (changeSceneInProgress)
        {
            return;
        }

        StartCoroutine(SwichSceneCoroutine(sceneName));
    }

    private IEnumerator SwichSceneCoroutine(SceneName sceneName)
    {
        changeSceneInProgress = true;

        OnSceneGoingToChange.Invoke(sceneChangeDuration);

        yield return new WaitForSeconds(sceneChangeDuration);

        SceneData sceneData = scenesData.Find(x => x.sceneName == sceneName);
        if (sceneData.sceneFileName != null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneData.sceneFileName);
        }

        changeSceneInProgress = false;
    }

}


public enum SceneName
{
    Menu,
    Game
}
