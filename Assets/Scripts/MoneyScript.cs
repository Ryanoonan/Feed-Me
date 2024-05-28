using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    public float value;

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject moneySpawner = GameObject.FindWithTag("MoneySpawner");
            MoneySpawnerScript moneySpawnerScript = moneySpawner.GetComponent<MoneySpawnerScript>();
            moneySpawnerScript.DestroyMoney();
            
        }
    }
    
}
