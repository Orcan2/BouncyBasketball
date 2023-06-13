using DG.Tweening;
using UnityEngine;

public class DestroyCar : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vehicle")){
            other.gameObject.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 3).SetEase(Ease.InBounce);
            Destroy(other.gameObject, 3.5f);
        }
    }
    
}
