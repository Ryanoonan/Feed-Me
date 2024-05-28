using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartTextScript : MonoBehaviour
{
    public float disappearSpeed;
    bool gameStarted = false;
    //called on the first click of the game
    public void FirstClick() {
        gameStarted = true;
        
        

    }

    private void Update()
    {
        if (gameStarted)
        {
            TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
            Color currentColor = text.color;
            float fadeAmount = currentColor.a - 0.001f * Time.deltaTime * disappearSpeed;
            text.color = new Color(currentColor.r, currentColor.g, currentColor.b, fadeAmount);
            if (text.color.a <= 0)
            {
                gameObject.SetActive(false);
            }
        }
       
       
    }

}
