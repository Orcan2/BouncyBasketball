using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class HeliMissile : MonoBehaviour
{
    public float countdownTime = 10.0f;
    public float missileLifeTime = 0f;
    public bool readyToMove = false;
    public GameObject target;
    public ParticleSystem explosion,expPrefab;
    public int speed;
    public float rotationSpeed;

    void Start()
    {
        StartCoroutine(Countdown());
        StartCoroutine(lifeTime());
        target = GameObject.Find("BALL");
        //gameObject.transform.DOShakeRotation(10,Random.Range(10,25),10);
    }

    IEnumerator Countdown()
    {
        float timeLeft = countdownTime;
        
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeLeft--;
           // missileLifeTime++;
        }
        readyToMove = true;
        
        
    }
    IEnumerator lifeTime()
    {
        float timeLeft = missileLifeTime;

        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeLeft--;
            
        }
        expPrefab = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(expPrefab.transform.root.gameObject, 2f);
        Destroy(gameObject);
    }
        private void Update()
    {
        
        if (readyToMove)
        {
            
            gameObject.GetComponent<Rigidbody>().AddForce(speed * (target.transform.position - gameObject.transform.position).normalized);
            rotateRocket();
           
        }
       
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        expPrefab= Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(expPrefab.transform.root.gameObject,2f);
        Destroy(gameObject);
    }
    void rotateRocket()
    {
        var lookPos = target.transform.position - transform.position;
     
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed*Time.deltaTime);
        gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime));
    }

}
