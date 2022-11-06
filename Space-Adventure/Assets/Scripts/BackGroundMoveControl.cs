using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoveControl : MonoBehaviour
{
    float backgroundLocation;
    float distance = 10.18f;


    void Start()
    {
        backgroundLocation = transform.position.y;
        FindObjectOfType<Planets>().PlacePlanet(backgroundLocation);
    }


    void Update()
    {
        if (backgroundLocation+distance<Camera.main.transform.position.y)
        {
            BackGroundMove();
        }
    }

    void BackGroundMove()
    {
        backgroundLocation += (distance * 2);
        FindObjectOfType<Planets>().PlacePlanet(backgroundLocation);
        Vector2 newPosition = new Vector2(0, backgroundLocation);
        transform.position = newPosition;
    }
}
