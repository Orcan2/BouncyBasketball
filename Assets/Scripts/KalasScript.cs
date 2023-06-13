using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalasScript : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Araba"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity=true;
        }
    }
    private void Update()
    {
        if (gameObject.transform.localPosition.y < 2750)
        {
            Destroy(gameObject);
        }
    }
}
