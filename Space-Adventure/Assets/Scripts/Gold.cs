using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField]
    GameObject gold = default;

    public void goldActive()
    {
        gold.SetActive(true);
    }

    public void goldActiveClose()
    {
        gold.SetActive(false);
    }
}
