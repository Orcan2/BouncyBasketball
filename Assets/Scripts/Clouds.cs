using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    
    public float time;
    public int cloudcount=0;
    public GameObject[] clouds =  { };
    void Start()
    {
        InvokeRepeating("SpawnClouds", 2, time);
    }

    // Update is called once per frame
    void Update()
    {
        // x: -226 , 920 y:-10 , 180 z:5 , 50
    }
    public void SpawnClouds()
    {
        Instantiate(clouds[Random.Range(0, clouds.Length)],new Vector3(Random.Range(-226f,920),Random.Range(-10,180),Random.Range(20,70)), Quaternion.identity);

    }
}
