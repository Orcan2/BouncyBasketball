using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LewerTouchDetection : MonoBehaviour
{
    public bool lewertouch=false;
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            lewertouch = true;
            Debug.Log("LewerTouchDetection \t"+lewertouch);
            
            Invoke("Switch",0.1f );
        } 
        

    }
    public void Switch()
    {
        lewertouch = false;
    }
   
}
