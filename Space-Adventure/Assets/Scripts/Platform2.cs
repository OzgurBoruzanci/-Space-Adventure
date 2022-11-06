using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour
{
    [SerializeField]
    GameObject platform2 = default;

    EdgeCollider2D edCol2d;

    float time = 0;
    float min, max, objectWidht;
    float randomSpeed;
    bool move;
    //bool platformActive;

    //public bool PlatformActive
    //{
    //    get { return platformActive;}
    //    set { platformActive = value;}
    //}
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
        platform2 = GetComponent<GameObject>();
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
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            time += Time.deltaTime;
            Debug.Log(time);
            if (time > 3.0f)
            {
                platform2.SetActive(false);
            }
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
        //if (GameObject.FindGameObjectWithTag("Player"))
        //{
        //    GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
        //    time += Time.deltaTime;
        //    Debug.Log(time);
        //    if (time > 3.0f)
        //    {
        //        platform2.SetActive(false);
        //    }
        //}


    }
    
}
