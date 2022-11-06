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
        if (Options.EasyReadValue()==1)
        {
            speed = 0.3f;
            acceleration = 0.03f;
            maxSpeed = 1.5f;
        }
        if (Options.NormalReadValue()==1)
        {
            speed = 0.5f;
            acceleration = 0.05f;
            maxSpeed = 2.0f;
        }
        if (Options.HardReadValue()==1)
        {
            speed = 0.8f;
            acceleration = 0.08f;
            maxSpeed = 2.5f;
        }
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
