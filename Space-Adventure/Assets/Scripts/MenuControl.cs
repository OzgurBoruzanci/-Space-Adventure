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


    void Start()
    {
        if (Options.IsThereARecord()==false)
        {
            Options.EasyAssignValue(1);
        }
        if (Options.MusicIsThereARecord()==false)
        {
            Options.MusicAssignValue(1);
        }
        CheckMusicSettings();
    }

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
        if (Options.MusicReadValue()==1)
        {
            Options.MusicAssignValue(0);
            MusicControl.instance.PlayMusic(false);
            musicButton.image.sprite = musicIkons[0];
        }
        else
        {
            Options.MusicAssignValue(1);
            MusicControl.instance.PlayMusic(true);
            musicButton.image.sprite = musicIkons[1];
        }
    }

    void CheckMusicSettings()
    {
        if (Options.MusicReadValue() ==1 )
        {
            musicButton.image.sprite = musicIkons[1];
            MusicControl.instance.PlayMusic(true);
        }
        else
        {
            musicButton.image.sprite = musicIkons[0];
            MusicControl.instance.PlayMusic(false);
        }
    }
}
