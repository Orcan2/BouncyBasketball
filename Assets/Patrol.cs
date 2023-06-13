using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Patrol : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] obj = { };
    //public GameObject orbitingSpikes;
    public float turn_speed;
    public Animator anim;
    Vector3 rotation;
    bool diee;
    public VillainStatus villainStatus;
    void Start()
    {
        
        InvokeRepeating("patrolAround", 1, 3);
        //orbitingSpikes.transform.DORotate(new Vector3(179, 180, 360), 3).SetLoops(-1,LoopType.Yoyo);
    }

    
    void  patrolAround()
    {
        if(diee==false)
        gameObject.transform.DOMove(obj[Random.Range(0,obj.Length)].transform.position, 4);
        
    }
    void Update()
    {
        if (diee == false) {
        Quaternion _lookRotation =Quaternion.LookRotation((ball.transform.position - transform.position).normalized);
         
        transform.rotation =Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * turn_speed);}
        diee = villainStatus.die;

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Ball"))
        {
            anim.SetInteger("hit", 1);
            Invoke("SetAnim", 1.5f);
       
        }
    }
    
    void SetAnim()
    {
        anim.SetInteger("hit", 0);
    }

}
