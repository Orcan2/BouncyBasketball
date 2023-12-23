using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kalemlik : MonoBehaviour
{
   
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "spike")
        {
            Destroy(other.gameObject);
        }
    }
}
