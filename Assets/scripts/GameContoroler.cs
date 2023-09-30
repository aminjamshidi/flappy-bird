using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoroler : MonoBehaviour
{
    #region privat const variable
    private const string selected_bird = " selectedbird";
    private const string green_bird = "greenbird";
    private const string red_bird = "redbird";
    private const string high_score = "highscore";
    #endregion
    #region privat variable
    #endregion
    #region public variable
    public static GameContoroler instance;
    #endregion
    #region public method
    public void SetHighScore(int y)
    {
        PlayerPrefs.SetInt(high_score, y);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(high_score);
    }
    public void SetSelectedBird(int x)
    {
        PlayerPrefs.SetInt(selected_bird, x);
    }
    public int GetSelectedBird()
    {
        return PlayerPrefs.GetInt(selected_bird);
    }
    public void UnLuckGreenBird()
    {
        PlayerPrefs.SetInt(green_bird, 1);
    }
    public int isGreenBirdUnluck()
    {
        return PlayerPrefs.GetInt(green_bird);
    }
    public void UnLuckRedBired()
    {
        PlayerPrefs.SetInt(red_bird, 1);
    }
    public int isRedBirdUnluck()
    {
        return PlayerPrefs.GetInt(red_bird);
    }
    #endregion
    #region privat method
    private void Awake()
    {
        MakeSingleton();
        IsTheGameStartedForTheFirstTime();
    }
    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void IsTheGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsTheGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(high_score, 0);
            PlayerPrefs.SetInt(red_bird, 1);
            PlayerPrefs.SetInt(green_bird, 1);
            PlayerPrefs.SetInt(selected_bird, 0);
            PlayerPrefs.SetInt("IsTheGameStartedForTheFirstTime", 0);
        }
    }
    #endregion
}
