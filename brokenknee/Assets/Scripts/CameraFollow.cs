using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Look;
    public float CamDist = 20;
    void Start()
    {
        Look = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(Look.position.x, Look.position.y, -CamDist);
    }
}
