
using UnityEngine;

public class Destroy : MonoBehaviour
{
    

   
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("floor"))
        {
            Destroy(gameObject, 1.5f);
        }
    }
}
