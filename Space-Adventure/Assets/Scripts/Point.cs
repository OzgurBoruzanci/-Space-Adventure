using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    int point;
    int hightPoint;
    int gold;
    int hightGold;

    bool collectPoints=true;


    [SerializeField]
    Text pointText = default;

    [SerializeField]
    Text goldText = default;

    [SerializeField]
    Text gameOverPointText = default;

    [SerializeField]
    Text gameOverGoldText = default;



    void Start()
    {
        goldText.text = "X" + gold;
    }

    
    void Update()
    {
        if (collectPoints)
        {
            point = (int)Camera.main.transform.position.y;
            pointText.text = "Score : " + point;
        }
    }

    public void GoldEarn()
    {
        FindObjectOfType<SoundControl>().GoldSound();
        gold++;
        goldText.text = "X" + gold;
    }
    public void GameOverText()
    {
        if (Options.EasyReadValue()==1)
        {
            hightPoint = Options.EasyPointReadValue();
            hightGold= Options.EasyGoldReadValue();
            if (point>hightPoint)
            {
                Options.EasyPointAssignValue(point);
            }
            if (gold>hightGold)
            {
                Options.EasyGoldAssignValue(gold);
            }
        }

        if (Options.NormalReadValue() == 1)
        {
            hightPoint = Options.NormalPointReadValue();
            hightGold = Options.NormalGoldReadValue();
            if (point > hightPoint)
            {
                Options.NormalPointAssignValue(point);
            }
            if (gold > hightGold)
            {
                Options.NormalGoldAssignValue(gold);
            }
        }

        if (Options.HardReadValue() == 1)
        {
            hightPoint = Options.HardPointReadValue();
            hightGold = Options.HardGoldReadValue();
            if (point > hightPoint)
            {
                Options.HardPointAssignValue(point);
            }
            if (gold > hightGold)
            {
                Options.HardGoldAssignValue(gold);
            }
        }

        collectPoints = false;
        gameOverPointText.text = "Point : " + point;
        gameOverGoldText.text = "X " + gold;
    }
}
