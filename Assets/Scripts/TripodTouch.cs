using DG.Tweening;
using UnityEngine;

public class TripodTouch : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Vehicle") )
        {
            gameObject.transform.DOLocalRotate(new Vector3(0, 0, 125), 3).OnComplete(() =>
            {
                gameObject.transform.DOLocalRotate(new Vector3(0, 0, 90), 4);

            }); 
        }
    }
    
}
