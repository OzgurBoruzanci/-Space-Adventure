using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Options
{
    public static string Easy = "Easy";
    public static string Normal = "Normal";
    public static string Hard = "Hard";

    public static string EasyPoint = "EasyPoint";
    public static string NormalPoint = "NormalPoint";
    public static string HardPoint = "HardPoint";

    public static string EasyGold = "EasyGold";
    public static string NormalGold = "NormalGold";
    public static string HardGold = "HardGold";

    public static string Music = "Music";
    

    public static void EasyAssignValue(int easy)
    {
        PlayerPrefs.SetInt(Options.Easy, easy);
    }
    public static int EasyReadValue()
    {
        return PlayerPrefs.GetInt(Options.Easy);
    }

    public static void NormalAssignValue(int normal)
    {
        PlayerPrefs.SetInt(Options.Normal, normal);
    }
    public static int NormalReadValue()
    {
        return PlayerPrefs.GetInt(Options.Normal);
    }


    public static void HardAssignValue(int hard)
    {
        PlayerPrefs.SetInt(Options.Hard, hard);
    }
    public static int HardReadValue()
    {
        return PlayerPrefs.GetInt(Options.Hard);
    }



    public static void EasyPointAssignValue(int easyPoint)
    {
        PlayerPrefs.SetInt(Options.EasyPoint, easyPoint);
    }
    public static int EasyPointReadValue()
    {
        return PlayerPrefs.GetInt(Options.EasyPoint);
    }

    public static void NormalPointAssignValue(int normalPoint)
    {
        PlayerPrefs.SetInt(Options.NormalPoint, normalPoint);
    }
    public static int NormalPointReadValue()
    {
        return PlayerPrefs.GetInt(Options.NormalPoint);
    }


    public static void HardPointAssignValue(int hardPoint)
    {
        PlayerPrefs.SetInt(Options.HardPoint, hardPoint);
    }
    public static int HardPointReadValue()
    {
        return PlayerPrefs.GetInt(Options.HardPoint);
    }



    public static void EasyGoldAssignValue(int easyGold)
    {
        PlayerPrefs.SetInt(Options.EasyGold, easyGold);
    }
    public static int EasyGoldReadValue()
    {
        return PlayerPrefs.GetInt(Options.EasyGold);
    }

    public static void NormalGoldAssignValue(int normalGold)
    {
        PlayerPrefs.SetInt(Options.NormalGold, normalGold);
    }
    public static int NormalGoldReadValue()
    {
        return PlayerPrefs.GetInt(Options.NormalGold);
    }


    public static void HardGoldAssignValue(int hardGold)
    {
        PlayerPrefs.SetInt(Options.HardGold, hardGold);
    }
    public static int HardGoldReadValue()
    {
        return PlayerPrefs.GetInt(Options.HardGold);
    }


    public static void MusicAssignValue(int music)
    {
        PlayerPrefs.SetInt(Options.Music, music);
    }
    public static int MusicReadValue()
    {
        return PlayerPrefs.GetInt(Options.Music);
    }


    public static bool IsThereARecord()
    {
        if (PlayerPrefs.HasKey(Options.Easy) || PlayerPrefs.HasKey(Options.Normal) || PlayerPrefs.HasKey(Options.Hard))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool MusicIsThereARecord()
    {
        if (PlayerPrefs.HasKey(Options.Music))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
