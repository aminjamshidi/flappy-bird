using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplay : MonoBehaviour
{
    #region privat variabl
    [SerializeField]
    private Text scoreText, endScore, bestScore, gameOverText;

    [SerializeField]
    private Button restartGameButton, instructionsButton;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject[] birds;

    [SerializeField]
    private Sprite[] medals;

    [SerializeField]
    private Image medalImage;
    #endregion
    #region public variabl
    public static gameplay instance;
    public FadingContoroler fader;
    #endregion
    #region privat method
    private void Start()
    {
        fader = GameObject.FindObjectOfType<FadingContoroler>();
    }
    private  void Awake()
    {
        MakeInstance();
        Time.timeScale = 0f;
    }
    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    #region public method
    public void PausePanel()
    {
        pausePanel.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        endScore.text = birdcontoroler.birdobject.currentscore + "";
        bestScore.text = GameContoroler.instance.GetHighScore() + "";
        Time.timeScale = 0f;
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => GoOnrGame());
    }
    public void GoOnrGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {

       fader. FADEIN("game scene");
    }
    public void MainMenu()
    {
       fader.FADEIN("main menu");
    }
    public void PLAYGAME()
    {
        scoreText.gameObject.SetActive(true);
        birds[GameContoroler.instance.GetSelectedBird()].SetActive(true);
        instructionsButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ShowDeadMood(int x)
    {
        pausePanel.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        endScore.text = x + "";
        if (x > GameContoroler.instance.GetHighScore())
        {
            GameContoroler.instance.SetHighScore(x);
        }
        bestScore.text = GameContoroler.instance.GetHighScore()+"";
        if (x <= 20)
        {
            medalImage.sprite = medals[0];
        }
        else if (x > 20 && x <= 40)
        {
            medalImage.sprite = medals[1];
            if (GameContoroler.instance.isGreenBirdUnluck() == 0)
            {
                GameContoroler.instance.UnLuckGreenBird();
            }
        }
        else if (x > 40)
        {
            medalImage.sprite = medals[2];
            if (GameContoroler.instance.isGreenBirdUnluck() == 0)
            {
                GameContoroler.instance.UnLuckGreenBird();
            }
            else if (GameContoroler.instance.isRedBirdUnluck() == 0)
            {
                GameContoroler.instance.UnLuckRedBired();
            }
        }
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => RestartGame());
    }
    public void SetCurrentScore(int s)
    {
        scoreText.text = s + "";
    }
    #endregion

}
