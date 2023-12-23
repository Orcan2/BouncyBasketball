using System.Collections;

using DG.Tweening;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    private IEnumerator coroutine;
    public roboticarm r;

   
    private void OnCollisionEnter(Collision collision)
    {
        if (!r.taken)
        {
            coroutine = wait();
            StartCoroutine(coroutine);
        }
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        gameObject.transform.DOMove(new Vector3(180,47,0), 1.5f);
    }
    
}
