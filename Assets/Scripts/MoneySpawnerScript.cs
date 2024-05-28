    using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class MoneySpawnerScript : MonoBehaviour
{
    public GameObject moneyPrefab;
    
    public GameObject destinationGameObject;
    public float destVariance;
    public int force;
    private float t; //delete after test
    public float spawnrate;

    public void SpawnMoney(float value, float size) {
        Vector3 destination = destinationGameObject.transform.position;
        GameObject moneyInstance =  Instantiate(moneyPrefab,gameObject.transform.position, Quaternion.identity);
        Rigidbody moneyRb = moneyInstance.GetComponent<Rigidbody>();
        Vector3 forceDirection = new Vector3((Random.value-0.5f)*destVariance,0,(Random.value - 0.5f)*destVariance) + destination;
        moneyRb.AddForce(forceDirection* force);
        MoneyScript moneyScript = moneyInstance.GetComponent<MoneyScript>();
        moneyScript.value = value;
        
    }

    public void DestroyMoney() {
        GameObject[] MoneyArr = GameObject.FindGameObjectsWithTag("Money");
        float totalMoney = 0;
        foreach(GameObject g in MoneyArr) {
            MoneyScript moneyScript = g.GetComponent<MoneyScript>();
            float moneyMade = moneyScript.value;
            totalMoney += moneyMade;
            Destroy(g);
        }
        GameManagerScript.instance.MoneyAmountChanged((int) totalMoney);
      
    }
}
