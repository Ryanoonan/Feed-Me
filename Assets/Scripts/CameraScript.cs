using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    
    Vector3 offset = new Vector3(0,6,-8) ;
    public float speed; 
    bool mouseOnButton;
    float constant = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !mouseOnButton) {
            Vector2 Tpos = Input.GetTouch(0).deltaPosition;
            transform.Translate(-Tpos.x * speed * constant, -Tpos.y * speed * constant, 0);
            
            
        }        
    }
    public void MouseOverUI(bool b) {
        mouseOnButton = b;
      
    }
}
