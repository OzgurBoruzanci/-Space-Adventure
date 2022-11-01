using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    float acceleration;
    float speed;
    float maxSpeed;

    bool move=true;

    void Start()
    {
        speed = 0.5f;
        acceleration = 0.05f;
        maxSpeed = 2.0f;
    }

    
    void Update()
    {
        if (move)
        {
            MoveCamera();
        }
    }

    void MoveCamera()
    {
        transform.position+=transform.up*speed*Time.deltaTime;
        speed += acceleration * Time.deltaTime;
        if (speed>maxSpeed)
        {
            speed = maxSpeed;
        }
    }

}
