using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class level4 : MonoBehaviour
{
    public GameObject chair,PinBox,pencilCase,ball,pin,spikebybooks,spikebybookspos;
    public int chairrotatef;
    public Quaternion q;
    public float t,exp,force;
   
    GameObject clonePin;
    public Vector3 pinRotation;
    int i = 0;
    int k = 0;
    
    public GameObject[] pins = new GameObject[3];
    public GameObject[] pinInsPos = new GameObject[3];
    

    void Start()
    {
             
        pencilCase.transform.DOMove(new Vector3(10, pencilCase.transform.position.y, 0), 15).SetLoops(-1,LoopType.Yoyo);
        pencilCase.transform.DOShakeRotation(5, 20, 10, 90).SetLoops(-1,LoopType.Restart);
        //sequence.Append(chair.DOMove())
        //chair.transform.DOMove(chair.transform.position - new Vector3(50, 0, 0), 3).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        //DOTween.Sequence().SetDelay(3f).AppendInterval(transform.DO)
        InvokeRepeating("pinInstantiate", 1, 0.5f);
        InvokeRepeating("spikeballbooks", 1, 3.5f);
        
        
        InvokeRepeating("secondPinInstantiate", 1, 1 );
        //bookDesign();
        // chair.transform.DOLocalRotate(new Vector3(0, 0, 180), 1,RotateMode.FastBeyond360)/*.SetLoops(-1, LoopType.Yoyo)*/;
    }
    
    void pinInstantiate()
    {


           
        if (ball.transform.position.x >= -140 && ball.transform.position.x < 20)
        {
            
           
        clonePin = Instantiate(pins[i], new Vector3(ball.transform.position.x + 1 *ball.GetComponent<Rigidbody>().velocity.magnitude , PinBox.transform.position.y, PinBox.transform.position.z)/*PinBox.transform.position + new Vector3(-55, 0, 0)*/, new Quaternion(pinRotation.x, pinRotation.y, pinRotation.z, 0));
            if (clonePin.transform.position.x > 20)
            {
                Destroy(clonePin);
            }    
          
            clonePin.GetComponent<Rigidbody>().AddForce(0, -300, 0);
           
            Destroy(clonePin, 3);} 
         
             i++;
        if (i >= 3) { i = 0; }



    }
    void secondPinInstantiate()
    { 
        if (k < 3)
        {
           clonePin =Instantiate(pin, /*new Vector3(130,37,0)*/pinInsPos[k].transform.position, Quaternion.identity);
           
           clonePin.GetComponent<Rigidbody>().AddForce(0, force*Time.deltaTime, 0,ForceMode.Impulse);
            clonePin.GetComponent<Rigidbody>().AddTorque(force, force, force);
            Destroy(clonePin, 1.5f);
           // Beklee2();
            k++;
            
        }
        if (k == 3)
            k = 0;
    }
    
    void Update() 
    {
        chair.transform.Rotate(0, 0, chairrotatef * Time.deltaTime);
 
    }
    void spikeballbooks()
    {
        
       GameObject clone= Instantiate(spikebybooks, spikebybookspos.transform.position, Quaternion.identity);
        Destroy(clone, 20);
        
    }
    
   


}
