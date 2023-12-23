using DG.Tweening;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update 38
    void Start()
    {
        gameObject.transform.DOLocalMoveY(gameObject.transform.position.y + 50, 1).SetLoops(-1, LoopType.Yoyo);
        gameObject.transform.DOLocalRotate(new Vector3(270, 0, -90), 1).SetLoops(-1,LoopType.Yoyo);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.GetComponent<Rigidbody>().AddForce(0, 10000, 0);
            Debug.Log("Arrrroww");
        }
    }
}
