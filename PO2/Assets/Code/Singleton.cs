using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton 
{
    private static Singleton Instance;
    public static Singleton GetInstance
    { 
    get
        {
            if (Instance == null)
            {
                Instance = new Singleton();
            }
            return Instance;
        }
     }

    public bool PlayerColl = false;
    public int Test = 1;
    public bool Holding = false;
    public int Recipecount = 0;
    public List<GameObject> RecipeList = new List<GameObject>();
    public int Slicecount = 1;
    public int Tipcnt = 1;
    public int Coin = 0;
    public int Placecnt = 4;
    public Stack<GameObject> PlateList = new Stack<GameObject>();
}
