using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axisControlRight : MonoBehaviour
{
    public roboticarm axisctrl;
    private void OnCollisionEnter(Collision collision)
    {
        axisctrl.touchOnRight = true;
    }
}
