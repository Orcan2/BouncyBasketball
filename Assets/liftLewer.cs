using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftLewer : MonoBehaviour
{
    public bool l1;
    
    private void OnCollisionEnter(Collision collision)
    {
        l1 = !l1;
        
    }
   public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            l1 = !l1;
        }
    }
}
