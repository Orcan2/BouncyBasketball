using DG.Tweening;
using UnityEngine;

public class decoyBAll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.DOMove(new Vector3(transform.position.x, transform.position.y-6, transform.position.z), 0.2f).SetLoops(-1,LoopType.Yoyo);
    }

    
}
