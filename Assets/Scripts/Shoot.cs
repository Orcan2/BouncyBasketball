
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Vector3 recoverpos = new Vector3( 690, 80, 0 );
    
    public bool inBounce=false;
    public int touchCount = 0;
    public float bounceforce, spaceBetweenPoints;
    public float forcemultiplear=0.1f;
    public Rigidbody rb;
    Vector3 StartPos;
    Vector3 EndPos;
    Vector3 direction;
    //Vector3 ClampedForce;
    public Vector3 max = new Vector3();
    public Vector3 min = new Vector3();
    public bool ReadyToShoot;

 
    


    public void Bounce()
    {
        rb.AddForce(Vector3.up * bounceforce, ForceMode.Impulse);
    }
    public void Update()
    {
        direction = StartPos - EndPos;
        if (Input.GetMouseButtonUp(0))
        {
            if (ReadyToShoot == true)
            {
                yolla();
                ReadyToShoot = false;
            }
            
        }
        if (touchCount % 2 != 0)
        {
            
            Bounce();
            touchCount = 0;
        }
        

    }

    public void OnMouseDown()
    { 
        if (ReadyToShoot == true) {
            rb.isKinematic = true;
            
            
            }
        
        StartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1616));


    }
    
    public void OnMouseUp()
    {
      
        rb.isKinematic = false;
        
        direction = StartPos - EndPos;
        inBounce = false;
        
        
        

    }
    public void yolla()
    {
        direction.x = Mathf.Clamp(direction.x, min.x, max.x);
        direction.y = Mathf.Clamp(direction.y, min.y, max.y);
        direction.z = 0f;
        rb.velocity = direction * forcemultiplear;
    }
    public void OnMouseDrag()
    {
        EndPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 13));

        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            
            ReadyToShoot = true;
            Bounce();
            if (inBounce == false)
            {
                touchCount++;
            }
        }
        if (collision.gameObject.CompareTag("spike"))
        {
            
            rb.velocity = new Vector3(0,0,0);
            Debug.Log("öldün çýk");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "goback")
        {
            rb.transform.position = recoverpos;
        }
        if (other.gameObject.tag == "hoopassist")
        {
            rb.velocity = new Vector3(rb.velocity.x/10f,rb.velocity.y,0f);
        }
    }
    
   
}
