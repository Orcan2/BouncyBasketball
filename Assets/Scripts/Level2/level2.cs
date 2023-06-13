using DG.Tweening;
using UnityEngine;
using System.Collections;

public class level2 : MonoBehaviour
{
    public GameObject Tripod,verticalSpkikeLauncher, lewer, SpikeWheel, SpikeWheel2, button, Magnet, Araba, button1, Araba1, spike, SpikeSpawnPoint, rightHand, wall, spikeAtTunnel1, spikeAtTunnel2;
    public bool lewerstate, lewerstate2 = true;
    public bool lewerTouched, buttonTouched, button1Touched, fist;
    public float speed, val;
    GameObject instantiatedCar;
    
    bool instantiated = false;
    //public Animation anim;
    public Vector3 vector1, vector2, vector3, vector4;
    

    // true=1 false=0 1830
    public void Start()
    {
        Magnet.transform.DOMove(new Vector3(1240, Magnet.transform.position.y, Magnet.transform.position.z), 5).SetLoops(-1, LoopType.Yoyo);
                    InstantiateCar();
        verticalSpkikeLauncher.transform.DOMove(new Vector3(629.5f, 270, 0), 5).SetLoops(-1, LoopType.Yoyo);
        //spikeAtTunnel1.transform.DOMove(vector1, 2).OnComplete(() => { spikeAtTunnel1.transform.DOMove(vector2, 2).OnComplete(() => { spikeAtTunnel1.transform.DOMove(vector3, 2).OnComplete(() => { spikeAtTunnel1.transform.DOMove(vector4, 2).OnComplete(() => { twen(); });  }); }); });
        twen1();
        twen2();
    }
    

    public Tween twen1()
    {

        return spikeAtTunnel1.transform.DOMove(vector1, 2).OnComplete(() => { spikeAtTunnel1.transform.DOMove(vector2, 2).OnComplete(() => { spikeAtTunnel1.transform.DOMove(vector3, 2).SetEase(Ease.InBounce).OnComplete(() => { spikeAtTunnel1.transform.DOMove(vector4, 2).OnComplete(() => { twen1(); }); ; }); }); });
    }

    public Tween twen2()
    {

        return spikeAtTunnel2.transform.DOMove(vector3, 2).OnComplete(() => { spikeAtTunnel2.transform.DOMove(vector4, 2).OnComplete(() => { spikeAtTunnel2.transform.DOMove(vector1, 2).SetEase(Ease.InBounce).OnComplete(() => { spikeAtTunnel2.transform.DOMove(vector2, 2).OnComplete(() => { twen2(); }); ; }); }); });
    }





    public void Update()

    {
        
        fist = wall.GetComponent<FistTouch>().fistTouch;
        lewerTouched = lewer.GetComponent<LewerTouchDetection>().lewertouch;
        buttonTouched = button.GetComponent<ButtonCollideDetection>().buttontouch;
        button1Touched = button1.GetComponent<Button2Touch>().Button1Touched;
        if (lewerTouched)
        {
            if (lewerstate == true)
            {
                lewer.transform.DORotate(new Vector3(90, 90, 0), 2);
                lewerstate = false;
            }
            else if (lewerstate == false)
            {
                lewer.transform.DORotate(new Vector3(0, 90, 0), 2);
                lewerstate = true;
            }


            if (lewerstate == true)
            {
                Tripod.transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
            }

            if (lewerstate == false)
            {
                Tripod.transform.DOLocalRotate(new Vector3(0, 0, 90), 1);


            }
        }
        if (buttonTouched||Input.GetKeyDown(KeyCode.Space))
        {
            button.transform.DOLocalMoveX(1349, 0.5f).OnComplete(() => { button.transform.DOLocalMoveX(1345, 0.5f); });
            ReleaseCar();
            instantiated = false;
            Invoke("InstantiateCar",1.5f);
        }
        if (button1Touched)
        {

            button1.transform.DOLocalMove(new Vector3(-29.31f, 92.9f, 0), 0.5f);
            Araba1.GetComponent<Rigidbody>().isKinematic = false;
            Araba1.GetComponent<Rigidbody>().useGravity = true;
            Araba1.GetComponent<Rigidbody>().AddForce(0, -2, 0, ForceMode.Acceleration);

        }
        if (fist)
        {
            
           InstantiateSpike();
            

        }
        SpikeWheel.transform.Rotate(0, 0, 70 * Time.deltaTime);
        SpikeWheel2.transform.Rotate(0, 0, 500 * Time.deltaTime);
    }
    public void ReleaseCar()
    {
        instantiatedCar.GetComponent<Rigidbody>().isKinematic = false;
        instantiatedCar.transform.parent = null;
        instantiatedCar.GetComponent<Rigidbody>().useGravity = true;
        instantiatedCar.GetComponent<Rigidbody>().AddForce(0, -100, 0, ForceMode.Acceleration);
        



    }
    public void InstantiateCar()
    {
        if (instantiated == false) {
            instantiatedCar = Instantiate(Araba, Magnet.transform.position + new Vector3(0, val, 0), Quaternion.identity);
            instantiatedCar.transform.parent = Magnet.transform; }
            instantiated = true;
        

    }
    public void InstantiateSpike()
    {

        Instantiate(spike, SpikeSpawnPoint.transform.position, SpikeSpawnPoint.transform.rotation);
        Debug.Log("instantiated");
    }
    
}
            





    

   

