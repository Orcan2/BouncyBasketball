using DG.Tweening;
using UnityEngine;

public class VillainStatus : MonoBehaviour
{
    int hitCount = 0;
    public bool die = false;
    public GameObject bridge,hooverboard,island,carrierCloud,ball;
    public Vector3 destination;
    public float time;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++;
            Debug.Log("vuruldum!!!");
            if (hitCount == 1)
            {
                
                gameObject.GetComponent<Animator>().enabled = false;
                hooverboard.transform.SetParent(null);

                //bridge.transform.DORotate(new Vector3(0, 0, 0), 2);
                //island.transform.DOMove(new Vector3(870, 0, 104), 5).SetEase(Ease.InOutBounce);
                
                hooverboard.transform.DOScale(new Vector3(0, 0, 0),3).SetEase(Ease.InBounce);
                Destroy(hooverboard, 3);
                carrierCloud.transform.DOMove(ball.transform.position + new Vector3(0, 0.2f, 0), 5);
                die = true;
                //ball.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            }
        }
        
    }
    void Update()
    {
        if (ball.GetComponent<Rigidbody>().velocity.x <= 2&& die)
        {
            
            ball.isStatic = true;
            ball.transform.parent = carrierCloud.transform;
            carrierCloud.transform.DOMove(destination, time);

        }
        if (carrierCloud.transform.position == destination)
        {
            ball.transform.parent = null;
            ball.isStatic = false;
        }
    }
    
  
}
