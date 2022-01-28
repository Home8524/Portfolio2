using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RecipeTimer : MonoBehaviour
{
    public Slider Slider1;
    public Slider Slider2;
    public Slider Slider3;
    public GameObject Fillcolor2;
    public GameObject Fillcolor3;
    private float Speed;
    private bool coll;
    // Start is called before the first frame update
    void Start()
    {
        Slider1.value = 1;
        Slider2.value = 1;
        Slider3.value = 1;
        Speed = -10.0f;
    }
    
    private void FixedUpdate()
    {
        //407
        if(transform.position.x>50&&!coll&&transform.tag=="Re1")
        {
            transform.Translate(Speed, 0.0f, 0.0f);
            Speed += 0.02f;
        }
        else if(transform.position.x > 30 && !coll && transform.tag == "Re2")
        {
            transform.Translate(Speed, 0.0f, 0.0f);
            Speed += 0.02f;
        }
        if(Slider1.value!=0)
            Slider1.value -= Time.deltaTime * 0.03f;
        else if(Slider2.value!=0)
        {
            Slider2.value -= Time.deltaTime * 0.03f;
            Image Img1 = Fillcolor2.GetComponent<Image>();
            Img1.color = new Color(1.0f, 1.0f, 0.0f);
            Image Img2 = Fillcolor3.GetComponent<Image>();
            Img2.color = new Color(1.0f, 1.0f, 0.0f);
        }
        else if(Slider3.value!=0)
        {
            Slider3.value -= Time.deltaTime * 0.03f;
            Image Img2 = Fillcolor3.GetComponent<Image>();
            Img2.color = new Color(1.0f, 0.0f, 0.0f);
        }
        else
        {
            Singleton.GetInstance.Recipecount--;
            for(int i=Singleton.GetInstance.RecipeList.Count-1;i>=0;--i)
            {
                if(Singleton.GetInstance.RecipeList[i].transform.name==transform.name)
                {
                    Singleton.GetInstance.RecipeList.Remove(Singleton.GetInstance.RecipeList[i]);
                }
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.position.x < transform.position.x)
            coll = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        coll = false;
    }
}
