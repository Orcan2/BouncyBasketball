using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamTransition : MonoBehaviour
{
    public GameObject Camera,Camera2,floatingCourt,pota;
    public Aircraft T;
    public GameObject[] objects = new GameObject[6];
   // Vector3 mainCamPos;
    bool control=false;
   
    IEnumerator bekle()
    {
        yield return new WaitForSeconds(2);
        Camera2.SetActive(false); Camera.SetActive(true);pota.SetActive(true);
        foreach(GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
   
    void Update()
    {
        if (T.CamTransition == true || Input.GetKeyDown(KeyCode.Space))
        {
            Camera.SetActive(false);
            Camera2.SetActive(true);
            // Camera2.transform.DOMove(Camera2.transform.position + new Vector3(0, -50, 0), 8).OnComplete(() => { Camera2.transform.DOMove(new Vector3(2192, -93, -512), 1); }).OnComplete(() => Camera2.transform.DOMove(mainCamPos, 1)).OnComplete(() => { Camera2.SetActive(false); Camera.SetActive(true);}) /*.OnComplete(() => Camera.SetActive(true))*/;
            var sequence = DOTween.Sequence();
            sequence.Append(Camera2.transform.DOMove( new Vector3(1483,-73,-512), 5));
            sequence.Append(Camera2.transform.DOMove(new Vector3(2192, -93, -512), 1))/*.OnComplete(() => { floatingCourt.transform.DOLocalRotate(new Vector3(0, 0, -180), 1.5f); }))*/;
            
            //sequence.Append(Camera2.transform.DOMove(mainCamPos, 1).OnComplete(()=> { Camera2.SetActive(false); Camera.SetActive(true); }));
           

            T.CamTransition = false;
        }
        if( control == false && Camera2.transform.position == new Vector3(2192, -93, -512) )
        {
            floatingCourt.transform.DOLocalRotate(new Vector3(0, 0, -180), 1.5f).SetEase(Ease.InBounce);
            StartCoroutine(bekle());
            control = true;
        }
    }
    
}
