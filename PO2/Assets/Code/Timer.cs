using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Slider Slider1;
    public GameObject Obj;
    private Text TimerText;
    private int fTime;
    public AudioClip Timeout;
    private AudioSource As;
    private bool flag = false;
    public GameObject In1;
    public GameObject In2;
    void Start()
    {
        Slider1.value = 1;
        TimerText = GameObject.Find("TimerText").GetComponent<Text>();
        fTime = 180;
        Invoke("Ready", 0.0f);
        As = transform.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        Slider1.value -= 0.00011f;
        if(Slider1.value<0.33)
        {
            Image Tmp = Obj.GetComponent<Image>();
            Tmp.color = new Color(1.0f, 0.0f, 0.0f);
        }
        else if (Slider1.value < 0.66)
        {
            Image Tmp = Obj.GetComponent<Image>();
            Tmp.color = new Color(1.0f, 1.0f, 0.0f);
        }
        int M = fTime / 60;
        int S = fTime % 60;
        string test = "0" + S.ToString();
        if(M==0&&S==30)
        {
            if(!flag)
                As.Play();
            flag = true;
        }
        if(S>9)
            TimerText.text = "0" + M + " : " + S;
        else
            TimerText.text = "0" + M + " : " + test;
    }
    void Ready()
    {
        Invoke("Go", 2.0f);
    }
    void Go()
    {
        In1.SetActive(false);
        In2.SetActive(true);
        InvokeRepeating("TimeCount", 1.0f,1.0f);
    }
    void TimeCount()
    {
        In2.SetActive(false);
        if (fTime != 0)
            fTime -= 1;
        else
        {
            CancelInvoke();
            As.clip = Timeout;
            As.Play();
            Invoke("Next_Stage", 2.0f);
        }
    }
    void Next_Stage()
    {
        SceneManager.LoadScene("Result");
    }
}
