using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    Sprite[] musicIkons = default;

    [SerializeField]
    Button musicButton = default;

    bool musicOpen=true;

    

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void HightScore()
    {
        SceneManager.LoadScene("HightScore");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Music()
    {
        if (musicOpen)
        {
            musicOpen = false;
            musicButton.image.sprite = musicIkons[0];
        }
        else
        {
            musicOpen = true;
            musicButton.image.sprite = musicIkons[1];
        }
    }
}
