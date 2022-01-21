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
    // Start is called before the first frame update
    void Start()
    {
        Slider1.value = 1;
        Slider2.value = 1;
        Slider3.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
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
        else
        {
            Slider3.value -= Time.deltaTime * 0.03f;
            Image Img2 = Fillcolor3.GetComponent<Image>();
            Img2.color = new Color(1.0f, 0.0f, 0.0f);
        }

    }
}
