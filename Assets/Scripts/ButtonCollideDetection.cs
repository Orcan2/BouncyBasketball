
using UnityEngine;

public class ButtonCollideDetection : MonoBehaviour
{
    public bool buttontouch = false,CarInstantiated;
    public GameObject obj1;
    public void Degis()
    {
        buttontouch = false;
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            buttontouch = true;   
        }
    }
    public void LateUpdate()
    {
        if (buttontouch == true)
        {
            buttontouch = false;
        }
    }

}
