using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinZpos : MonoBehaviour
{
    public float t;
    void Update()
    {
        if (gameObject.transform.position.z != 0)
        {
            gameObject.transform.position -= new Vector3(0, 0, gameObject.transform.position.z*Time.deltaTime*t);
        }
    }
}
