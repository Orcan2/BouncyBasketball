using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce( Random.Range(-4,5), 0, 0);
        if (rb.transform.position.x < -226 || rb.transform.position.x > 920)
        {
            Destroy(gameObject);
        }
    }
}
