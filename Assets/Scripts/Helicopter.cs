using DG.Tweening;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public int force;
    public Rigidbody rb;
    
    
    public GameObject Top,ArkaPervane, AnaPervane;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.transform.DOMove(new Vector3(930, 102, 70), 15).SetLoops(-1, LoopType.Yoyo);
    }
    
    // Update is called once per frame
    void Update()
    {
        Top.transform.Translate(rb.transform.position.x,0,0);
        if (rb.transform.position.x > 920)
        {
            gameObject.transform.rotation = Quaternion.Euler(-70, -90, -90);
            Debug.Log("930");
        }
        if (rb.transform.position.x <-118)
        {
            gameObject.transform.rotation = Quaternion.Euler(-70, 90, -90);
            Debug.Log("-120");
        }
        ArkaPervane.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, 10 * force), ForceMode.Impulse);
        AnaPervane.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 10 * force, 0), ForceMode.Impulse);
    }
}
