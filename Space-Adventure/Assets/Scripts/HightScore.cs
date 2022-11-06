using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightScore : MonoBehaviour
{
    public Text easyPoint,easyGold,normalPoint,normalGold,hardPoint,hardGold;
    
    void Start()
    {
        easyPoint.text = "Point : " + Options.EasyPointReadValue();
        easyGold.text="X "+Options.EasyGoldReadValue();
        
        normalPoint.text = "Point : " + Options.NormalPointReadValue();
        normalGold.text = "X " + Options.NormalGoldReadValue();

        hardPoint.text = "Point : " + Options.HardPointReadValue();
        hardGold.text = "X " + Options.HardGoldReadValue();
    }


}