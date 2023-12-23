using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scissor : MonoBehaviour
{
    public Vector3 scissorV1,scissorV2;
    public GameObject s1, s2;
    void Start()
    {
        s1.transform.DOLocalRotate(scissorV1, 0.5f).SetLoops(-1,LoopType.Yoyo);
        s2.transform.DOLocalRotate(scissorV2, 0.5f).SetLoops(-1, LoopType.Yoyo);

    }

}
        
