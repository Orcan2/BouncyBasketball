using DG.Tweening;
using UnityEngine;

public class followw : MonoBehaviour
{
    
    public Transform PlayerTr;
    private Vector3 _cameraOffset;
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    public bool mouseup;
    public Camera cam;
    public GameObject ball,heli;
    public Vector3 directionn;
    public float currentFieldOfView,mouseDown,mouseUp;
    
    
    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }
    void Start()
    {
        
        _cameraOffset = transform.position - PlayerTr.position;
    }
    

    void LateUpdate()
    {
        
            directionn = ball.GetComponent<NewBehaviourScript>().direction;
            mouseup = ball.GetComponent<NewBehaviourScript>().mouseUp;
            Vector3 newPos = PlayerTr.position + _cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
            if (mouseup == false && directionn.normalized.magnitude > 0)
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, mouseDown/*40_80*/, Time.deltaTime);
            }
            currentFieldOfView = cam.fieldOfView;
            if (mouseup == true)
            {
                cam.fieldOfView = Mathf.Lerp(currentFieldOfView, mouseUp/*26_60*/, Time.deltaTime);
            }
        
       
        
    }

   
}