using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject Slider;
    public GameObject MainMenu;
    public GameObject JoystickJump;
    public GameObject SignBoard;
    public GameObject Joystick;
    public GameObject GoldImage;

    void Start()
    {
        
        GameOverPanel.SetActive(false);
        UIOpen();
    }

    
    void Update()
    {
        
    }
    public void GameOver()
    {
        FindObjectOfType<SoundControl>().GameOverSound();
        GameOverPanel.SetActive(true);
        FindObjectOfType<Point>().GameOverText();
        FindObjectOfType<PlayerMoving>().GameOver();
        UIClose();
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    void UIOpen()
    {
        Slider.SetActive(true);
        Joystick.SetActive(true);
        MainMenu.SetActive(true);
        JoystickJump.SetActive(true);
        SignBoard.SetActive(true);
        GoldImage.SetActive(true);

    }
    void UIClose()
    {
        Slider.SetActive(false);
        Joystick.SetActive(false);
        MainMenu.SetActive(false);
        JoystickJump.SetActive(false);
        SignBoard.SetActive(false);
        GoldImage.SetActive(false);
    }
}
