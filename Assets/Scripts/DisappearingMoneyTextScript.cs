using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisappearingMoneyTextScript : MonoBehaviour
{
    
    public float disappearSpeed;
    private float t;
    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        Color currentColor = text.color;
        float fadeAmount = currentColor.a - 0.001f * Time.deltaTime * disappearSpeed;
        text.color = new Color(currentColor.r, currentColor.g, currentColor.b, fadeAmount);
        if (currentColor.a <= 0)
        {
            Destroy(gameObject);
        }


    }
}
