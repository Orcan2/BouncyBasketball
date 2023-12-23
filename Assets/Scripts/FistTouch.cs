using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistTouch : MonoBehaviour
{
    public bool fistTouch=false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fist"))
        {
            fistTouch = true;
           
            
        }
        
    }
    private void LateUpdate()
    {
        fistTouch = false;
    }
}
