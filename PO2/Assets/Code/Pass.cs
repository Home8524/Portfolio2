using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pass : MonoBehaviour
{
    private bool coll;
    private GameObject Plate;
    public GameObject Tip1;
    public GameObject Tip2;
    public GameObject Tip3;
    public GameObject Tip4;
    private AudioSource As;
    private void Start()
    {
        As = transform.GetComponent<AudioSource>();
        coll = false;
    }
    private void Update()
    {
        if(coll)
        {
            PlateFollow Tmp = Plate.GetComponent<PlateFollow>();
            foreach(GameObject Rec in Singleton.GetInstance.RecipeList)
            {
                bool breaktest=false;
                if(Rec.tag=="Re1"&&Tmp.Cucumber&&Tmp.Rice&&Tmp.Seaweed&&!Tmp.Prawn)
                {
                    for(int i = Singleton.GetInstance.RecipeList.Count-1;i>=0;--i)
                    {
                        if(Singleton.GetInstance.RecipeList[i].name==Rec.name)
                        {
                            Singleton.GetInstance.RecipeList.Remove(Singleton.GetInstance.RecipeList[i]);
                            Destroy(Rec);
                            Singleton.GetInstance.Recipecount--;
                            breaktest = true;
                            As.Play();
                            Singleton.GetInstance.Tipcoin += Singleton.GetInstance.Tipcnt * 10;
                            Singleton.GetInstance.Coin += 36 + Singleton.GetInstance.Tipcnt * 10;
                            if (Singleton.GetInstance.Tipcnt < 4)
                                Singleton.GetInstance.Tipcnt++;
                        }
                    }
                }
                else if (Rec.tag == "Re2" && !Tmp.Cucumber && !Tmp.Rice && !Tmp.Seaweed && Tmp.Prawn)
                {
                    for (int i = Singleton.GetInstance.RecipeList.Count - 1; i >= 0; --i)
                    {
                        if (Singleton.GetInstance.RecipeList[i].transform.name == Rec.transform.name)
                        {
                            Singleton.GetInstance.RecipeList.Remove(Singleton.GetInstance.RecipeList[i]);
                            Destroy(Rec);
                            Singleton.GetInstance.Recipecount--;
                            breaktest = true;
                            As.Play();
                            Singleton.GetInstance.Tipcoin += Singleton.GetInstance.Tipcnt * 10;
                            Singleton.GetInstance.Coin += 36 + Singleton.GetInstance.Tipcnt * 10;
                            if (Singleton.GetInstance.Tipcnt < 4)
                                Singleton.GetInstance.Tipcnt++;
                        }
                    }
                }
                if (breaktest)
                    break;
             }
            Destroy(Plate.GetComponent<Rigidbody>());
            Plate.transform.position = new Vector3(3000.0f, 100.0f, 100.0f);
            Plate.GetComponent<PlateFollow>().coll = false;
            Singleton.GetInstance.PlateList.Push(Plate);
            coll = false;
            Singleton.GetInstance.Placecnt--;
            
            Tmp.Cucumber = false;
            Tmp.Prawn = false;
            Tmp.Rice = false;
            Tmp.Seaweed = false;
            Transform[] Clist = Tmp.GetComponentsInChildren<Transform>();
            for (int i = 1; i < Clist.Length; ++i)
            {
                if (Clist[i] != transform)
                    Destroy(Clist[i].gameObject);
            }
        }
        Text Coin = GameObject.Find("Coin").GetComponent<Text>();
        Coin.text = Singleton.GetInstance.Coin.ToString();
        Text TipText = GameObject.Find("TipText").GetComponent<Text>();
        TipText.text = "фа x  " + Singleton.GetInstance.Tipcnt;
        switch (Singleton.GetInstance.Tipcnt)
        {
            case 1:
                Tip1.SetActive(true);
                Tip2.SetActive(false);
                Tip3.SetActive(false);
                Tip4.SetActive(false);
                break;
            case 2:
                Tip2.SetActive(true);
                Tip1.SetActive(false);
                Tip3.SetActive(false);
                Tip4.SetActive(false);
                break;
            case 3:
                Tip3.SetActive(true);
                Tip2.SetActive(false);
                Tip1.SetActive(false);
                Tip4.SetActive(false);
                break;
            default:
                Tip4.SetActive(true);
                Tip2.SetActive(false);
                Tip3.SetActive(false);
                Tip1.SetActive(false);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Plate")
        {
            coll = true;
            Plate = other.gameObject;
        }
    }
}
