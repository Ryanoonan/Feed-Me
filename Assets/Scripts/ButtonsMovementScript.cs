using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ButtonsMovementScript : MonoBehaviour
{
    public bool mouseOverButtons;
    public float speed;
    public int clampMin;
    public int clampMax;
    float constant = 0.5f;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && mouseOverButtons)
        {
            Vector2 Tpos = Input.GetTouch(0).deltaPosition;
            transform.Translate(0, Tpos.y * speed * constant, 0);
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y,clampMin,clampMax), transform.localPosition.z);


        }

    }
    public void MouseOverButtons(bool b)
    {
        mouseOverButtons = b;
    }

}
