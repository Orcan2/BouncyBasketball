using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PencilCase2 : MonoBehaviour
{
 
    public GameObject[] pencils = new GameObject[3];
    Rigidbody rv;
    public Vector3 v;
    public float Xval1,Xval2;
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            pencils[i].GetComponent<Rigidbody>().isKinematic = true;
        }
        rv = gameObject.GetComponent<Rigidbody>();
        rv.isKinematic = true;
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            rv.isKinematic = false;
            rv.AddForce(100, 0, 0);
           
            for (int i = 0; i < 3; i++)
            {
                pencils[i].GetComponent<Rigidbody>().isKinematic = false;


                switch (i)
                {
                    case 0:
                        pencils[i].GetComponent<Rigidbody>().AddForce(v);
                        pencils[i].transform.DOLocalRotate(new Vector3(75, 90, -90),3);
                        break;
                    case 1:
                        pencils[i].GetComponent<Rigidbody>().AddForce(v+new Vector3(Xval1,0,0));
                        pencils[i].transform.DOLocalRotate(new Vector3(80, 90, -90), 1.5f);
                        break;
                    case 2:
                        pencils[i].GetComponent<Rigidbody>().AddForce(v + new Vector3(Xval2, 0, 0));
                        pencils[i].transform.DOLocalRotate(new Vector3(70, 90, -90), 2.5f);
                        break;
                }

            }

        }
    }
   
}
