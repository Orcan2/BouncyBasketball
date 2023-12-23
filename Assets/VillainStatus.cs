using DG.Tweening;
using UnityEngine;

public class VillainStatus : MonoBehaviour
{
    int hitCount = 0;
    public bool die = false;
    public bool cloudarrived=false;
    public bool cloudarrived2 = false;
    public GameObject hooverboard,island,carrierCloud,ball,restOfMap;
    public Vector3 destination;
    public float time;

    
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++;
            Debug.Log("vuruldum!!!");
            if (hitCount == 2)
            {
                restOfMap.SetActive(true);
                gameObject.GetComponent<Animator>().enabled = false;
                hooverboard.transform.SetParent(null);

             
                
                hooverboard.transform.DOScale(new Vector3(0, 0, 0),3).SetEase(Ease.InBounce);
                Destroy(hooverboard, 3);
                ball.GetComponent<Rigidbody>().velocity -= ball.GetComponent<Rigidbody>().velocity;
                ball.GetComponent<SphereCollider>().enabled = false;
                carrierCloud.transform.DOMove(ball.transform.position + new Vector3(0, 0.2f, 0), 2).OnComplete(() => Debug.Log("ere")).OnComplete(()=>cloudarrived=true);
                die = true;
                
              
            }
        }
        
    }
    void Update()
    {
        if (ball.GetComponent<Rigidbody>().velocity.x <= 5 && die &&cloudarrived)
        {
            ball.GetComponent<SphereCollider>().enabled = false;
            ball.isStatic = true;
            ball.transform.parent = carrierCloud.transform;
            carrierCloud.transform.DOMove(destination, time)/*.OnComplete(() => ball.transform.DOMove(new Vector3(1150, 80, 0), 3))*/.OnComplete(() => cloudarrived = false);
             
             

        }
        if (ball.transform.position.x >= 1150)
        {
            ball.transform.SetParent(null);
            ball.GetComponent<SphereCollider>().enabled = true;
        }
        
    }
    //void fun()
    //{
       
    //    ball.GetComponent<SphereCollider>().enabled = true;
    //    ball.transform.parent = null;
    //    ball.isStatic = false;
     
    //}
    
}

