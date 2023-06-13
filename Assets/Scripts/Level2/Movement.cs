using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public Rigidbody rb;
    Vector3 StartPos, EndPos;
    public float force;

   
    
    
    public Vector3 max = new Vector3();
    public Vector3 min = new Vector3();
    
    public Vector3 direction;
    public bool inBounce = false;
    void Update()
    {

        direction = StartPos - EndPos;



        

    }
    public void OnMouseDrag()
    {
        EndPos = Input.mousePosition;


    }
    public void OnMouseDown()
    {
        
        {
        
            rb.isKinematic = true;
            
            StartPos = Input.mousePosition;


         
        }
    }

    public void OnMouseUp()
    {

        
        {
            rb.isKinematic = false;
            Yolla();
            
            
            
        }




    }
    
    
    public void Yolla()
    {
        direction.x = Mathf.Clamp(direction.x, min.x, max.x);
        direction.y = Mathf.Clamp(direction.y, min.y, max.y);
        direction.z = 0f;
        rb.velocity = direction * force;
    }
}
