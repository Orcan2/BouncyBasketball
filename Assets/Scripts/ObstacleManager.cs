using DG.Tweening;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
  
    public GameObject obs1,obs2,obs3,spikeLauncher, spikeLauncher2,obs4,floor;

    public int altsinir;
    public int duration;
    
    void Start()
    {
        obs1.transform.DOMove(new Vector3(obs1.transform.position.x, altsinir, 0), duration).SetLoops(-1,LoopType.Yoyo);
        obs3.transform.DOMove(new Vector3(obs3.transform.position.x, altsinir, 0), duration).SetLoops(-1, LoopType.Yoyo);
        obs2.transform.DOMove(new Vector3(obs2.transform.position.x, 22, 0), 3).SetLoops(-1, LoopType.Yoyo);
        obs4.transform.DOMove(new Vector3(500, obs4.transform.position.y, 0), 3).SetLoops(-1, LoopType.Yoyo);
        spikeLauncher.transform.DOMove(new Vector3(-22, 54.6f, 0), 5).SetLoops(-1, LoopType.Yoyo);
        spikeLauncher2.transform.DOMove(new Vector3(240, spikeLauncher2.transform.position.y, 0), 7).SetLoops(-1, LoopType.Yoyo);
        floor.transform.DOLocalRotate(new Vector3(-180, 0, 0), 2).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        
    }

    
}
