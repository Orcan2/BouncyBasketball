using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftLewer2 : MonoBehaviour
{
    public bool l2;
    private void OnCollisionEnter(Collision collision)
    {
        l2 =! l2;
       
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            l2 = !l2;
        }
    }
}
