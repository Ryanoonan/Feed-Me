using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public float speed = 0;
    Vector3 destination;
    GameObject gameManager;
    GameManagerScript gameMangerScript;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FatMan")
        {
            gameManager = GameObject.FindWithTag("GameLogic");
            gameMangerScript = gameManager.GetComponent<GameManagerScript>();
            gameMangerScript.PattyEaten();
            Destroy(gameObject);

        }
        else if (other.gameObject.tag == "EndOfTreadmill")
        {
            
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
        }
       
    }
   
}
