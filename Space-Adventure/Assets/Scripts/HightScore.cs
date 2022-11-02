using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightScore : MonoBehaviour
{
    int hightScore = 0;
    List<int> hightScores;

    //[SerializeField]
    //Text hightScoreText = default;
    
    void Start()
    {
        hightScore = PlayerPrefs.GetInt("Score");
        hightScores.Add(hightScore);
        for (int i = 0; i < hightScores.Count; i++)
        {

        }
    }


    void Update()
    {
        
    }
}