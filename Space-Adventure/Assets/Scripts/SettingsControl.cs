using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    public Button easyButton, normalButton, hardButton;
    void Start()
    {
        if (Options.EasyReadValue()==1)
        {
            easyButton.interactable = false;
            normalButton.interactable = true;
            hardButton.interactable = true;
            
        }
        if (Options.NormalReadValue()==1)
        {
            easyButton.interactable = true;
            normalButton.interactable = false;
            hardButton.interactable = true;
            
        }
        if (Options.HardReadValue()==1)
        {
            easyButton.interactable = true;
            normalButton.interactable = true;
            hardButton.interactable = false;
           
        }
    }

    
    void Update()
    {
        
    }

    public void Chosen(string level)
    {
        switch (level)
        {
            case "Easy":
                Options.EasyAssignValue(1);
                Options.NormalAssignValue(0);
                Options.HardAssignValue(0);
                easyButton.interactable = false;
                hardButton.interactable = true;
                normalButton.interactable = true;
                break;
            case "Normal":
                Options.EasyAssignValue(0);
                Options.NormalAssignValue(1);
                Options.HardAssignValue(0);
                easyButton.interactable = true;
                hardButton.interactable = true;
                normalButton.interactable = false;
                break;
            case "Hard":
                Options.EasyAssignValue(0);
                Options.NormalAssignValue(0);
                Options.HardAssignValue(1);
                easyButton.interactable = true;
                hardButton.interactable = false;
                normalButton.interactable = true;
                break;
            default:
                break;
        }

    }
    
}
