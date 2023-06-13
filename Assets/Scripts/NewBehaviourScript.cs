using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool Instantiated = false;
    public bool mouseUp=true;
    public Rigidbody rb;
    Vector3 StartPos, EndPos;
    public float force, spaceBetweenPoints;
    public int numberOfPoints;
    public GameObject PointPrefab;
    public GameObject[] Points;
    public bool ReadyToCalculate = true;
    Vector3 recoverpos = new Vector3(690, 80, 0);
    public Vector3 max = new Vector3();
    public Vector3 min = new Vector3();
    public bool ReadyToShoot=false;
    public Vector3 direction;
    public bool inBounce = false;
    public Camera cam;
    //public int touchCount = 0;
    //public LineRenderer lr;
    
    void Update() {
        
        direction = StartPos - EndPos;

        
        
        if (ReadyToCalculate == true){Calculate(Points);}
        
    }
    public void OnMouseDrag()
    {
        EndPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 13));
        

    }
    public void OnMouseDown()
    {
        mouseUp = false;
        if (ReadyToShoot == true) {
            //lr.enabled = true;
            //lr.positionCount = 2;
        ReadyToCalculate = true;
        rb.isKinematic = true;
        if (Instantiated == false)
        {
            Points = new GameObject[numberOfPoints];
            for (int i = 0; i < numberOfPoints; i++)
            {
                Points[i] = Instantiate(PointPrefab, rb.position, Quaternion.identity);

            }
            Instantiated = true;
        }
        StartPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 13));
            
            
            //lr.useWorldSpace = true;
            
            //lr.numCapVertices = 10;
            //lr.SetPosition(0, rb.transform.position);
    }
    }
    
    public void OnMouseUp()
    {
        mouseUp = true;
        if (ReadyToShoot == true)
        {
            rb.isKinematic = false;
            Yolla();
            //lr.enabled = false;
            ReadyToShoot = false;
            ReadyToCalculate = false;
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].transform.position = new Vector3(0, -50, 0);

            }
        }




    }
    public void Calculate(GameObject[] g)
    {
        for(int i = 0; i < g.Length; i++)
        {
            g[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }
    Vector3 PointPosition(float t)
    {
        Vector3 currentPointPosition = (Vector3)transform.position + (force * t * direction) + (t * t) * 0.5f * Physics.gravity;
        return currentPointPosition;
    }
    public void Yolla()
    {
        direction.x = Mathf.Clamp(direction.x, min.x, max.x);
        direction.y = Mathf.Clamp(direction.y, min.y, max.y);
        direction.z = 0f;
        rb.velocity = direction * force;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor")|| collision.gameObject.CompareTag("island1"))
        {

            ReadyToShoot = true;
            //if (inBounce == false)
            //{
            //    touchCount++;
            //}
        }
        if (collision.gameObject.CompareTag("spike"))
        {
            
            rb.velocity = new Vector3(0, 0, 0);
            Debug.Log("öldün çýk");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("goback"))
        {
            rb.transform.position = recoverpos;
        }
        if (other.gameObject.CompareTag("hoopassist"))
        {
            rb.velocity = new Vector3(rb.velocity.x / 10f, rb.velocity.y, 0f);
        }
    }

}



