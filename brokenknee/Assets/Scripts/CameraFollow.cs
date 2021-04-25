using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Look;
    public float CamDist;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(Look.position.x, Look.position.y, -CamDist);
    }
}
