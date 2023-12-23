using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour
{
    public float t;
    private void Update()
    {
        if (gameObject.transform.position.z != 0)
        {
            gameObject.transform.position -= new Vector3(0, 0, gameObject.transform.position.z*Time.deltaTime*t);
        }
        if (gameObject.transform.position.y >= 0)
        {
            gameObject.transform.GetComponent<Rigidbody>().AddForce(0, -750*Time.deltaTime, 0);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("floor"))
    //    {
    //        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    //    }
    //}
}
