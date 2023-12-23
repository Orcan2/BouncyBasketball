using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axisControlLeft : MonoBehaviour
{
    public roboticarm axisctrl;
    private void OnCollisionEnter(Collision collision)
    {
        axisctrl.touchOnLeft = true;
    }
}
