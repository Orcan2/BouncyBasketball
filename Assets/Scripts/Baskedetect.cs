using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baskedetect : MonoBehaviour
{
    public Rigidbody ball;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {

        if (ball.velocity.y < 0)
        {
            Debug.Log("Basket!");
        }
            
        
    }
}
