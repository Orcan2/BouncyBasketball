using DG.Tweening;
using System.Collections;
using UnityEngine;

public class roboticarm : MonoBehaviour
{
    public bool touchOnLeft = false;
    public bool taken = false;
    public bool touchOnRight =false;
    public  liftLewer lew1;
    public liftLewer2 lew2;
    bool instantiated = false;
    
    public GameObject claw1,claw2,arm,payload,payloadDummy,payloadPrefab;

    private IEnumerator coroutine;



    private void Update()
    {
            
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(claw1.transform.rotation.z);
        }
        if (lew1.l1 && arm.transform.localPosition.x<=0.47f /*&& !touchOnRight*/)
        {
            touchOnLeft = false;
            arm.transform.Translate(8 * Time.deltaTime,0,0);
            
        }
        if(!lew1.l1&& arm.transform.localPosition.x >= -0.47f && !touchOnLeft)
        {
            touchOnRight = false;
            arm.transform.Translate(-8 * Time.deltaTime, 0,0);
        }
        if (lew2.l2 /*&& !touchOnLeft*/)
        {

            claw1.transform.DOLocalRotate(new Vector3(0, 0, -60), 5, RotateMode.Fast);
            claw2.transform.DOLocalRotate(new Vector3(0, 0, 60), 5, RotateMode.Fast);
           
        }
        if (!lew2.l2)
        {
          
            claw1.transform.DOLocalRotate(new Vector3(0, 0, -25), 5, RotateMode.Fast);
            claw2.transform.DOLocalRotate(new Vector3(0, 0,25), 5, RotateMode.Fast);
           
        }
        if (arm.transform.localPosition.x<-0.370 && claw1.transform.rotation.z<=0.24f)
        {           
            payloadGrabbed();
        }
        if (lew1.l1&&lew2.l2&&taken)
        {
            payloadRelease();
            
        }
        
         
    }
    void payloadGrabbed()
    {
        touchOnRight = false;
        taken = true;
        payload.SetActive(false);
        payloadDummy.SetActive(true);
        //payloadDummy.transform.position = new Vector3(arm.transform.position.x, payloadDummy.transform.position.y, payloadDummy.transform.position.z);
        

    }
    void payloadRelease()
    {
        if (!instantiated) { 
        Instantiate(payloadPrefab, payloadDummy.transform.position, payloadDummy.transform.rotation);
            instantiated = true;
        }
       
        payloadDummy.SetActive(false);
        taken = false;
        payload.SetActive(true);
        payloadDummy.isStatic = false;
        coroutine = WaitAndPrint(2.0f);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        instantiated = false;
    }

}
