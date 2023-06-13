using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airTunnel : MonoBehaviour
{
    public int force;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball")|| other.gameObject.CompareTag("spike"))
        {
            
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,10*force,0));
        }
    }
}
