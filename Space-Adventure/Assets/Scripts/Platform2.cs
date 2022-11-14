using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Platform2 : MonoBehaviour
{
    [SerializeField]
    GameObject platform2 = default;


    EdgeCollider2D edCol2d;

    //int counter = 1000;

    //float time = 0;
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
        platform2 = GameObject.FindGameObjectWithTag("Platform2");
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
        //if (platform2.tag == "Food")
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMoving>().JumpReset();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            platform2.SetActive(false);
        }
    }

    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //}

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
