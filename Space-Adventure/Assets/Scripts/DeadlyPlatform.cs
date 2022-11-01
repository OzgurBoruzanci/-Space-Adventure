using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyPlatform : MonoBehaviour
{
    EdgeCollider2D edCol2d;

    float min, max, objectWidht;
    float randomSpeed;
    bool move;

    public bool Move
    {
        get
        {
            return move;
        }
        set
        {
            move = value;
        }
    }

    void Start()
    {
        edCol2d = GetComponent<EdgeCollider2D>();
        randomSpeed = Random.Range(0.5f, 1.0f);

        objectWidht = edCol2d.bounds.size.x / 2;

        if (transform.position.x > 0)
        {
            min = objectWidht;
            max = ScreenCalculator.Instance.Width - objectWidht;
        }
        else
        {
            min = -ScreenCalculator.Instance.Width + objectWidht;
            max = -objectWidht;
        }


    }

    
    void Update()
    {
        if (move)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }
}
