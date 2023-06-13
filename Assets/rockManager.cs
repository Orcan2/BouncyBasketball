using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class rockManager : MonoBehaviour
{
    public float force, FallMultiplear;
    GameObject r1, r2;

    private void Start()
    {
        r1 = gameObject.transform.GetChild(0).gameObject;
        r2 = gameObject.transform.GetChild(1).gameObject;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("island1")) {
            r1.SetActive(true);
            r1.GetComponent<Rigidbody>().AddForce(-force+300, 0, 0);
           // r1.transform.position = new Vector3(r1.transform.position.x, r1.transform.position.y, 0);
            //r1.GetComponent<Rigidbody>().velocity += FallMultiplear * Physics.gravity.y * Time.deltaTime * Vector3.up;
            r1.transform.SetParent(null);

            r2.SetActive(true);
            r2.GetComponent<Rigidbody>().AddForce(force, 0, 0);
            //r2.transform.position = new Vector3(r2.transform.position.x, r2.transform.position.y, 0);
            //r2.GetComponent<Rigidbody>().velocity += FallMultiplear * Physics.gravity.y * Time.deltaTime * Vector3.up;
            r2.transform.SetParent(null);
            
            Destroy(gameObject);
            Destroy(r1,25);
            Destroy(r2, 25);
        }
        
    }
    private void Update()
    {
        r1.transform.position = new Vector3(r1.transform.position.x, r1.transform.position.y, 0);
        r2.transform.position = new Vector3(r2.transform.position.x, r2.transform.position.y, 0);
        if (r1.GetComponent<Rigidbody>().velocity.y<=0&& r2.GetComponent<Rigidbody>().velocity.y <= 0) { 
        r1.GetComponent<Rigidbody>().velocity += FallMultiplear * Physics.gravity.y * Time.deltaTime * Vector3.up;
        r2.GetComponent<Rigidbody>().velocity += FallMultiplear * Physics.gravity.y * Time.deltaTime * Vector3.up;}
        

    }
}
