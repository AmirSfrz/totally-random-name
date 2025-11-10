using System;
using UnityEngine;

[Serializable]
public struct SceneData
{
    [SerializeField]
    public SceneName sceneName;

    [SerializeField]
    public string sceneFileName;

    public SceneData(SceneName sceneName, string data)
    {
        this.sceneName = sceneName;
        this.sceneFileName = data;
    }
}