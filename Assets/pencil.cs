using DG.Tweening;
using UnityEngine;

public class pencil : MonoBehaviour
{
    public Vector3 pos;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("floor"))
        {
            gameObject.transform.DOMove(pos, 0.5f); //128,48,-4,5---140,46.5,-4-----150,46,-3
            transform.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
