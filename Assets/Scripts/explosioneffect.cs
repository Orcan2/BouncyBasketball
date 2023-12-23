using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosioneffect : MonoBehaviour
{
    public ParticleSystem exp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("thropy"))
        {
            exp.Play();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            exp.Play();
        }
    }
}
