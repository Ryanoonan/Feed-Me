using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BigNumber 
{
    public static string[] OrderOfMagStrings = {"", "K", "M", "B", "T", "q", "Q", "s", "S" };
    public static string NumToBigString(float f)
    {
        float magnitude = Mathf.Log10(f);
       
        int i = 0;
        while (magnitude >= 5 + 3*i )
        {
            i++;
        }
       
        int displayf = (int) (f / Mathf.Pow(10,i*3));
        
        return displayf + OrderOfMagStrings[i];



    }
}
