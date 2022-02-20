using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultPage : MonoBehaviour
{
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    [SerializeField] Text T1;
    [SerializeField] Text T2;
    [SerializeField] Text T3;
    [SerializeField] Text T4;
    void Start()
    {
        T1 = GameObject.Find("Text1").GetComponent<Text>();
        T2 = GameObject.Find("Text2").GetComponent<Text>();
        T3 = GameObject.Find("Text3").GetComponent<Text>();
        T4 = GameObject.Find("Text4").GetComponent<Text>();

        int tmp = Singleton.GetInstance.Coin - Singleton.GetInstance.Tipcoin;
        int tmp2 = tmp / 36;
        T1.text = "배달된 주문 x "+tmp2+"                                               "+tmp;
        T2.text = "Tip                                                        " +
            "          " + Singleton.GetInstance.Tipcoin;
        T3.text = "실패한 주문 x " + Singleton.GetInstance.FailRe + "                                               " 
            + Singleton.GetInstance.FailRe*20;
        T4.text = "합계 :                                                       " +
            "       " + Singleton.GetInstance.Coin;
        if (Singleton.GetInstance.Coin >= 40)
            Invoke("Active1", 1.0f);
    }
    void Active1()
    {
        Star1.SetActive(true);
        if (Singleton.GetInstance.Coin >= 120)
            Invoke("Active2", 1.0f);
    }
    void Active2()
    {
        Star2.SetActive(true);
        if (Singleton.GetInstance.Coin >= 160)
            Invoke("Active3", 1.0f);
    }
    void Active3()
    {
        Star3.SetActive(true);
    }
}
