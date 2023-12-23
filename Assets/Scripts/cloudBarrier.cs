using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudBarrier : MonoBehaviour
{
    public float force;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.GetComponent<Rigidbody>().AddForce(0, force, 0);
         
        }
    }
}
