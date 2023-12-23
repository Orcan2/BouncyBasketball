using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipwreck : MonoBehaviour
{
    
    public float explosionF,radius;
    public GameObject explosioneffect,exposite;
    public ParticleSystem fog;
    void Start()
    {
        Explode();
        fog.Play();
    }

    
    void Explode()
    {
        Instantiate(explosioneffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObj in colliders)
        {
            if (nearbyObj.GetComponent<Rigidbody>()!=null)
            nearbyObj.GetComponent<Rigidbody>().AddExplosionForce(explosionF, exposite.transform.position,radius);
        }
    }
}
