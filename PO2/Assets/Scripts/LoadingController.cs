using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    static string NextScene;

    [SerializeField] private Image ProgressBar;
    private float Crossline;

    void Start()
    {
        StartCoroutine("LoadScene");
        Crossline = 0.7f;
    }


    public static void SetLoad(string _SceneName)
    {
        NextScene = _SceneName;

        SceneManager.LoadScene("MainLoadIngScene");
       // SceneManager.LoadScene("NextSceneUI");
    }

    IEnumerator LoadScene()
    {
        AsyncOperation Aop = SceneManager.LoadSceneAsync(NextScene);
        Aop.allowSceneActivation = false;

        float FakeLoadingTime = 0.0f;

        while(!Aop.isDone)
        {
            yield return null;

            if(Aop.progress < Crossline)
                ProgressBar.fillAmount = Aop.progress;
            else
            {
                FakeLoadingTime += Time.unscaledDeltaTime;
                ProgressBar.fillAmount = Mathf.Lerp(Crossline, 1.0f, FakeLoadingTime);

                if(ProgressBar.fillAmount >= 1.0f)
                {
                    Aop.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

}
