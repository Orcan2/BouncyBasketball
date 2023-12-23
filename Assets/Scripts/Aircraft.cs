using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aircraft : MonoBehaviour
{
    public GameObject blade1, blade2,namlu1,namlu2,roket,ball,throphy,defeatedHeli;
    public int speed,insForce,thropyParts=0;
    bool defeated=false;
    public bool CamTransition = false;
    bool sequenceCtrl = false;
  
    public int bladef;
    public Vector3 rotation;
    public ParticleSystem particle,explosion,exp;

    
 
    public int force;
    
    void Start()
    {
       
        gameObject.transform.DOMoveY(gameObject.transform.position.y + 5, 1.5f).SetLoops(-1,LoopType.Yoyo);
        InvokeRepeating("Roket", 1, 10);
        
        explosion.Play();
    }
    
    public void defeat()
    {
        CamTransition = true;
        ball.GetComponent<Rigidbody>().velocity -= ball.GetComponent<Rigidbody>().velocity;
       throphy.transform.DOScale(new Vector3(5, 5, 5), 1);
       throphy.transform.DOMove(new Vector3(1483, -56, 0), 5).OnComplete(() => throphy.SetActive(false));
        if (!defeated)
        {
            blade1.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 100, 0) * 10000 * Time.deltaTime, ForceMode.Acceleration);
            blade2.GetComponent<Rigidbody>().AddTorque(-10000 * Time.deltaTime * new Vector3(0, 100, 0), ForceMode.Acceleration);
        }
        defeated = true;

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("thropy"))
        {
            
            particle.Play();
             exp =Instantiate( explosion, particle.transform.position, Quaternion.identity);
            Destroy(exp, 2.5f);
            blade1.transform.SetParent(null);
            blade2.transform.SetParent(null);
            blade1.GetComponent<Rigidbody>().AddForce(-bladef, bladef, 0, ForceMode.Impulse);
            blade1.GetComponent<Rigidbody>().AddTorque(Vector3.up * bladef*100);
            blade2.GetComponent<Rigidbody>().AddForce(bladef, bladef, 0, ForceMode.Impulse);
            blade2.GetComponent<Rigidbody>().AddTorque(Vector3.up * bladef*100);
            Destroy(blade1, 2);
            Destroy(blade2, 2);
            if (!sequenceCtrl)
            {
                var sequence = DOTween.Sequence();
                sequence.Append(gameObject.transform.DORotate(new Vector3(314, 260, 7), 2));
                //sequence.Append(gameObject.transform.DORotate(new Vector3(-97, 0, 270), 1));
                //sequence.Append(gameObject.transform.DORotate(new Vector3(311, 100, 172), 1));
                //sequence.Append(gameObject.transform.DORotate(new Vector3(-95, 0, 270), 1));
                sequenceCtrl = true;

            }
           // gameObject.transform.DORotate(new Vector3(314, 260, 7), 1).OnComplete(()=> gameObject.transform.DORotate(new Vector3(-97, 0, 270),1)).OnComplete(() => gameObject.transform.DORotate(new Vector3(311, 100, 172),1).OnComplete(() => gameObject.transform.DORotate(new Vector3(-95, 0, 270), 1)));
           
            gameObject.transform.DOMove(new Vector3(1477,-154,29), 2).OnComplete(() => { defeatedHeli.SetActive(true);gameObject.SetActive(false); });
        }
    }

    void Update()
    {
        if (!defeated)
        {
            blade1.transform.Rotate(speed * Time.deltaTime * rotation);
            blade2.transform.Rotate(speed * Time.deltaTime * -rotation);
            //blade1.GetComponent<Rigidbody>().AddTorque(speed * Time.deltaTime * rotation);
            //blade2.GetComponent<Rigidbody>().AddTorque(-speed * Time.deltaTime * rotation);
        }

        if (thropyParts==4)
        {
            defeat();
        }

       
    }
    void Roket()
    {
        if (ball.transform.position.x >= 1000&&!defeated) { 
       GameObject roket1= Instantiate(roket, namlu1.transform.position, Quaternion.Euler(-90,0,0));
       GameObject roket2= Instantiate(roket, namlu2.transform.position, Quaternion.Euler(-90, 0, 0));
       roket1.GetComponent<Rigidbody>().AddForce(insForce * Time.deltaTime * Vector3.up, ForceMode.Impulse);
        roket1.GetComponent<Rigidbody>().AddTorque(Vector3.right * 10);
        roket2.GetComponent<Rigidbody>().AddForce(insForce * Time.deltaTime * Vector3.up, ForceMode.Impulse);
        roket2.GetComponent<Rigidbody>().AddTorque(Vector3.right * -10);
        }
    }
    
   
}
