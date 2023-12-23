using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class calcPrefab : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        if (transform.position.x <= 215)
        {
            transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 1.5f);
            Destroy(gameObject,2);
        }
    }
}
