
using UnityEngine;

public class HitDetect : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            gameObject.GetComponent<Animator>().enabled = false;
            Destroy(gameObject, 10);
        }
    }
    private void Update()
    {
        if (gameObject.transform.position.y < -400)
        {
            Destroy(gameObject);
        }
    }
}
