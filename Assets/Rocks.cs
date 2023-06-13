using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public GameObject bigRock,miniRock1, miniRock2;
    public float force;
    

    // Update is called once per frame
    void Update()
    {
        miniRock1.GetComponent<Rigidbody>().AddForce(new Vector3(force* Physics.gravity.y, force * Physics.gravity.y, 0), ForceMode.Impulse);
        miniRock2.GetComponent<Rigidbody>().AddForce(new Vector3(-force * Physics.gravity.y, force * Physics.gravity.y, 0), ForceMode.Impulse);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("island1"))
        {
           
            miniRock1.transform.parent=null;
            miniRock2.transform.parent = null;
            miniRock1.SetActive(true);
           // miniRock1.transform.Translate(new Vector3(-force, 0, 0));
            miniRock2.SetActive(true);
            //miniRock2.GetComponent<Rigidbody>().AddForce(new Vector3(force, 0, 0), ForceMode.Impulse);
            Destroy(bigRock);
            Destroy(gameObject,5);
        }
    }
}
