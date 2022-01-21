using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Slider Slider1;
    public GameObject Obj;
    private Text TimerText;
    private int fTime;
    void Start()
    {
        Slider1.value = 1;
        TimerText = GameObject.Find("TimerText").GetComponent<Text>();
        fTime = 180;
        InvokeRepeating("TimeCount", 1.0f, 1.0f);
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Slider1.value -= Time.deltaTime * 0.1f;
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
        if(S!=0)
            TimerText.text = "0" + M + " : " + S;
        else
            TimerText.text = "0" + M + " : " + test;
    }
    void TimeCount()
    {
        if (fTime != 0)
            fTime -= 1;
        else
            CancelInvoke();
    }
}
