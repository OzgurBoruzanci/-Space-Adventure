using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    EdgeCollider2D edCol2d;

    float min, max,objectWidht;
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

        if (Options.EasyReadValue() == 1)
        {
            randomSpeed = Random.Range(0.2f, 0.8f);
        }
        if (Options.NormalReadValue() == 1)
        {
            randomSpeed = Random.Range(0.5f, 1.0f);
        }
        if (Options.HardReadValue() == 1)
        {
            randomSpeed = Random.Range(0.8f, 1.5f);
        }

        objectWidht = edCol2d.bounds.size.x / 2;

        if (transform.position.x>0)
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag=="Foot")
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMoving>().JumpReset();
        }
    }

}
