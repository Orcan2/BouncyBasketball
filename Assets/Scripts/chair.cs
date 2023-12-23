using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class chair : MonoBehaviour
{
    Vector3 v1= new Vector3(-3000, 2000, 0);
    Vector3 v2=new Vector3(3000, 2000, 0);
    Vector3 v3 = new Vector3(0, 2000, 0);
    Vector3 v4 = new Vector3(1000, 3000, 0);
    public float force;
    public Vector3 target;
    Vector3[] vectorList = new Vector3[4];
    Sequence sequence;

    bool temas = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        { other.GetComponent<Rigidbody>().AddForce(vectorList[Random.Range(0, 4)], ForceMode.Acceleration); }
        else
        {
            target = gameObject.transform.position;
         
        }
    }
     
    void Start()
    {
              
        vectorList[0] = v1;
        vectorList[1] = v2;
        vectorList[2] = v3;
        vectorList[3] = v4;

        sequence.Append(gameObject.transform.DOMove(target, 4));
        

    }
    
    
}


