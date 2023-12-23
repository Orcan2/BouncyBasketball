using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class denemesil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var sequence = DOTween.Sequence();
        
        sequence.Append(gameObject.transform.DOMove(new Vector3(10, 10, 0), 2));
        sequence.Append(gameObject.transform.DOMove(new Vector3(20, 5, 0), 2));
        sequence.Append(gameObject.transform.DOMove(new Vector3(30, 20, 0), 2));
        sequence.Append(gameObject.transform.DOMove(new Vector3(40, 30, 0), 2));
        sequence.Append(gameObject.transform.DOMove(new Vector3(15, 0, 0), 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
