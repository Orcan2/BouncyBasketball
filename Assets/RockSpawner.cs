using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BigRock;
    private GameObject cBigRock;
  

    public rockManager rock;
    void Start()
    {
        InvokeRepeating("InstantiateRock", 1, 5);
       
        cBigRock = BigRock;
        
    }
    
    public void Update()
    {
        
       
    }
    void InstantiateRock()
    {
        cBigRock = Instantiate(BigRock, transform.position, Quaternion.identity);
        Destroy(cBigRock, 15);
    }
}
