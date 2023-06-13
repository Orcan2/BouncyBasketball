using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Decors : MonoBehaviour
{
    public GameObject car,cloud,ball,head1,head2,body,bottom;
    public float duration, shake, randomness;
    public int vibrate,height;
    public bool bulut=false;
    
    
    
    public float force;
    
   
    void Start()
    {
        car.transform.DOShakePosition(duration,shake, vibrate, randomness).SetLoops(-1,LoopType.Restart);
        head1.transform.DORotate(new Vector3(10, -20, 0), 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InBounce);
        head2.transform.DORotate(new Vector3(10, 200, 0), 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InBounce);
        body.transform.DORotate(new Vector3(-10, -90, 10), 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InBounce);
        bottom.transform.DORotate(new Vector3(0, 10, 10), 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InBounce);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ball.transform.position.y >=210 && ball.GetComponent<Rigidbody>().velocity.y>5&&bulut==false&& ball.transform.position.x <= 900)
        {
            GameObject cloudClone = Instantiate(cloud, ball.transform.position+new Vector3(0,2,0),Quaternion.identity);
            cloud.transform.DOPunchScale(new Vector3(3.5f, 3.5f, 3.5f), 1, 1);
            bulut = true;
            Invoke("Switch", 1.5f);
            Destroy(cloudClone, 4); 
        }
        
 
        
        
     

    }

    


    void Switch()
    {
        bulut = false;
    }
    
}
