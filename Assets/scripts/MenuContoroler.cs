using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuContoroler : MonoBehaviour
{
    #region privat variabl
    private bool isRedUnluck, isGreenUnluck;
    #endregion
    #region public variabl
    public static MenuContoroler instancemenu;
    public GameObject[] birds;
    #endregion
    #region privat method
    private void Awake()
    {
        Makeinstance();
    }
    private void Start()
    {
        birds[GameContoroler.instance.GetSelectedBird()].SetActive(true);
        CheckingBirdsLucks();
    }
    private void CheckingBirdsLucks()
    {
        if (GameContoroler.instance.isGreenBirdUnluck()==1)
        {
            isGreenUnluck = true;
        }
        else { isGreenUnluck = false; }
        if (GameContoroler.instance.isRedBirdUnluck() == 1)
        {
            isRedUnluck = true;
        }
        else { isRedUnluck = false; }
    }
    private void Makeinstance()
    {
        if (instancemenu == null) { instancemenu = this; }
    }
    #endregion
    #region public method
    public void ChangeBird()
    {
        if (GameContoroler.instance.GetSelectedBird() == 0)
        {
            if (isGreenUnluck)
            {
                birds[0].SetActive(false);
                GameContoroler.instance.SetSelectedBird(1);
                birds[GameContoroler.instance.GetSelectedBird()].SetActive(true);
            }
            else if (isRedUnluck)
            {
                birds[0].SetActive(false);
                GameContoroler.instance.SetSelectedBird(2);
                birds[GameContoroler.instance.GetSelectedBird()].SetActive(true);
            }
        }
        else if (GameContoroler.instance.GetSelectedBird() == 1)
        {
            if (isRedUnluck)
            {
                birds[1].SetActive(false);
                GameContoroler.instance.SetSelectedBird(2);
                birds[GameContoroler.instance.GetSelectedBird()].SetActive(true);

            }
            else
            {
                birds[1].SetActive(false);
                GameContoroler.instance.SetSelectedBird(0);
                birds[GameContoroler.instance.GetSelectedBird()].SetActive(true);
            }
        }
        else if (GameContoroler.instance.GetSelectedBird() == 2)
        {
            birds[2].SetActive(false);
            GameContoroler.instance.SetSelectedBird(0);
            birds[GameContoroler.instance.GetSelectedBird()].SetActive(true);
        }
    }
    public void PlayGame()
    {
        FadingContoroler.instancefade.FADEIN("game scene");
    }
    #endregion
}
