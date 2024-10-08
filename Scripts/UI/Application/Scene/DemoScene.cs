﻿using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class DemoScene : SceneBase
{
    private static readonly string sceneName = "Scenes/DemoScene";

    public override void OnEnter()
    {
        if(SceneManager.GetActiveScene().name!="DemoScene")
        {
            GameRoot.Instance.SwitchScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            PanelManager.Instance.Push(new DemoPanel("Hello Wrold!"));
        }
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        PanelManager.Instance.Clear();
    }

    private void SceneLoaded(Scene scene,LoadSceneMode mode)
    {
        PanelManager.Instance.Push(new DemoPanel("Hello Wrold!"));
    }
}
