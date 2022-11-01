using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    float spriteWidth;
    float screenHeight;
    float screenWidth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 tempScale = transform.lossyScale;

        spriteWidth = spriteRenderer.size.x;
        screenHeight = Camera.main.orthographicSize * 2.0f;
        screenWidth = screenHeight / Screen.height * Screen.width;
        tempScale.x = screenWidth / spriteWidth;
        transform.localScale = tempScale;
    }

    
    void Update()
    {
        
    }
}
