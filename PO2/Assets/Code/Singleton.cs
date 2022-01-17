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

}
