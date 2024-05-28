using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to store which ugrades have been bought, and method to caluclate price of upgrades
public class Upgrades
{
    static public int[] upgradeLevels = { 0, 0, 0, 0, 0, 0 };

    static public int[] upgradeCosts = { 15, 80, 500, 2500, 10000 };

 

    //Takes in price of current upgrade, and returns the new price of the upgrade
    //once it is bought
    public static void IncreasePrice(int ID)
    {

        if (ID == 0)
        {
            upgradeCosts[ID] = upgradeCosts[ID] + 5;
        }

        if (ID == 1 || ID == 2)
        {
            upgradeCosts[ID] = (int) (upgradeCosts[ID] * Mathf.Pow(1.2f, (float)upgradeLevels[ID]));
        }
        if (ID == 3)
        {
            upgradeCosts[ID] = (int)(upgradeCosts[ID] * Mathf.Pow(5f, (float)upgradeLevels[ID]));
        }

        
    }

    public static float ComputeUnitCalories()
    {
        return (300 + upgradeLevels[0]*200) * Mathf.Pow(1.2f, upgradeLevels[1]) * Mathf.Pow(1.15f,upgradeLevels[2]) * Mathf.Pow(2f,upgradeLevels[3]) ; //TODO: Replace this with real calculation

    }

    //Converts the weight amount changed into new money
    public static float weightToMoney(float weight)
    {
        return weight; //TODO: Create actual calculation
    }

    public static float CurrentSizeOfFood()
    {
        
        return Mathf.Pow(1.2f, upgradeLevels[2]) * 4 * Mathf.Pow(2.0f, upgradeLevels[3]) ; //4 is the initial food size
        
    }

    public static float CaloriesToWeight(float calories)
    {
        return calories / 1000f;
    }
}
