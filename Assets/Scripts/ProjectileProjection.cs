using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProjection : MonoBehaviour
{
    Shoot shoot;
   public LineRenderer lineRenderer;

    public int numPoints = 50;
    public float timeBetweenPoints = 0.1f;
    public LayerMask CollidableLayers;
    void Start()
    {
        shoot = GetComponent<Shoot>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = (int)numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = shoot.rb.position;
        Vector3 startingVelocity = shoot.rb.velocity;

        for(float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            if (Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }
        lineRenderer.SetPositions(points.ToArray());
    }

}
