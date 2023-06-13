using DG.Tweening;
using UnityEngine;

public class ThropyMovement : MonoBehaviour
{

    public float time1, time2;
    public GameObject bodyPart, t1, t2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            //gameObject.transform.DOMove(t1.position, time1).OnComplete(() => gameObject.transform.DOMove(t2.position, time2)).OnComplete(() => bodyPart.SetActive(true));
            gameObject.transform.DOMove(t1.transform.position, time1)
            .OnComplete(() => gameObject.transform.DOMove(t2.transform.position, time2));//.OnComplete(() => bodyPart.SetActive(true));


        }

    }
    
    void Update()
    {
        if (gameObject.transform.position == t2.transform.position)
        {
            bodyPart.SetActive(true);
            Destroy(gameObject );
        }
    }
} 