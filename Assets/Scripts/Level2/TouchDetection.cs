using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.other.CompareTag("floor"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (collision.other.CompareTag("Araba"))
        {
            Debug.Log("gsdfhgsdh");
        }
    }
}
