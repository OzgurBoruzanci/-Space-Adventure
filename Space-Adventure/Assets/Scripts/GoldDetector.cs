using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag=="Foot")
        {
            GetComponentInParent<Gold>().goldActiveClose();
            FindObjectOfType<Point>().GoldEarn();
        }
    }
}
