using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dingie : MonoBehaviour
{
    public GameObject[] cloudSea= new GameObject[15];
    void Start()
    {
        gameObject.transform.DORotate(new Vector3(280, 0, 255), 3).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        for(int i = 0; i <= 14; i++)
        {
            if(i%2==0)
            cloudSea[i].transform.DORotate(new Vector3(0, 0, 10), 2).SetLoops(-1, LoopType.Yoyo);
            else
            {
                cloudSea[i].transform.DORotate(new Vector3(0, 0, -10), 2).SetLoops(-1, LoopType.Yoyo);
            }
        }
    }

}
