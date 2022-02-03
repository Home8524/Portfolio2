using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    private string[] SceneName = { "NextScene_01", "Stage1" };

    private int Index;

    private void Start()
    {
        Index = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SetNextScene();
    }

    void SetNextScene()
    {
        if (Index >= SceneName.Length)
            return;

        LoadingController.SetLoad(SceneName[Index]);
        Index++;
    }
}
