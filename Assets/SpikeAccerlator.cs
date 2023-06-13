using DG.Tweening;
using UnityEngine;

public class SpikeAccerlator : MonoBehaviour
{
    public Vector3 vector1,vector2,vector3,vector4;
  
    // Update is called once per frame 896,-267/812,-309/718,-271/616,-314
    public void Start()
    {
        gameObject.transform.DOMove(vector1, 1).OnComplete(() => { gameObject.transform.DOMove(vector2, 1).OnComplete(() => gameObject.transform.DOMove(vector3, 1).OnComplete(() => gameObject.transform.DOMove(vector4, 1).OnComplete(() => Destroy(gameObject,2)))); });
        }
}
