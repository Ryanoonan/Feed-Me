using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class BarbecueScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Mouse over barbecue");
        }
    }
}
