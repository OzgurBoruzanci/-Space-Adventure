using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    int point;

    [SerializeField]
    Text pointText = default;
    void Start()
    {
        
    }

    
    void Update()
    {
        point = (int)Camera.main.transform.position.y;
        pointText.text = "Score : " + point;
    }
}
