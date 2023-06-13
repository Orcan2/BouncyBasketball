using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2Touch : MonoBehaviour
{
    public bool Button1Touched = false;
    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Button1Touched = true;
        }
    }
 

}
