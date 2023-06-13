using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aircraft : MonoBehaviour
{
    public GameObject blade1, blade2,namlu1,namlu2,roket;
    public int speed,insForce;
    public Vector3 rotation;

    
 
    public int force;
    
    void Start()
    {
        gameObject.transform.DOMoveY(gameObject.transform.position.y + 5, 1.5f).SetLoops(-1,LoopType.Yoyo);
        InvokeRepeating("Roket", 1, 10);


    }
  
    

    
    void Update()
    {
        blade1.transform.Rotate(speed * Time.deltaTime * rotation);
        blade2.transform.Rotate(speed * Time.deltaTime * -rotation);
    }
    void Roket()
    {
       GameObject roket1= Instantiate(roket, namlu1.transform.position, Quaternion.Euler(-90,0,0));
       GameObject roket2= Instantiate(roket, namlu2.transform.position, Quaternion.Euler(-90, 0, 0));
       roket1.GetComponent<Rigidbody>().AddForce(insForce * Time.deltaTime * Vector3.up, ForceMode.Impulse);
        roket1.GetComponent<Rigidbody>().AddTorque(Vector3.right * 10);
        roket2.GetComponent<Rigidbody>().AddForce(insForce * Time.deltaTime * Vector3.up, ForceMode.Impulse);
        roket2.GetComponent<Rigidbody>().AddTorque(Vector3.right * -10);
    }
   
}
