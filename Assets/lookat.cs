using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public GameObject projectile,namlu;
     GameObject CloneProjectile;
    public GameObject target;
    public bool instantiated=false;
    public float force;
    
    
   
    public bool forceApplied=false;

    IEnumerator Bekle()
    {
        instantiated = true;
        yield return new WaitForSeconds(2f);
        instantiated = false;
        
    }
   

    void Fonk()
    {
        if (instantiated==false) { 
            CloneProjectile = Instantiate(projectile, namlu.transform.position, Quaternion.identity);

            
            CloneProjectile.transform.LookAt(target.transform);
            CloneProjectile.GetComponent<Rigidbody>().AddForce(force  * (target.transform.position - CloneProjectile.transform.position).normalized,ForceMode.Acceleration);
                
            
            
            StartCoroutine(Bekle());
        }
        
        Destroy(CloneProjectile,3);




    }
    
}
