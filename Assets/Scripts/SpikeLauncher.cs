using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLauncher : MonoBehaviour
{
    public float  force=1;
    public float time;
    public Rigidbody projectile;
     Rigidbody clone;
    public GameObject namlu;

    private void Start()
    {
        InvokeRepeating("Launch", 1f, time);
    }

    // Update is called once per frame
    void Launch()
    {
        
        
            clone = Instantiate(projectile, namlu.transform.position, namlu.transform.rotation);

            clone.velocity = transform.TransformDirection(Vector3.up * 100*force);

        


    }
    

}
