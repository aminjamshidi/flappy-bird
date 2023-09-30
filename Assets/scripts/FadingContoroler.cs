using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingContoroler : MonoBehaviour
{
    #region privat variabl
    #endregion
    #region public variabl
    public static FadingContoroler instancefade;
    public Animator fadeing;
    public GameObject CavasOfFadeing;
    #endregion
    #region privat method
    private void Awake()
    {
        MakeSingleton();
    }
    private void MakeSingleton()
    {
        if (instancefade != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instancefade = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
        #region public method
    public void FADEIN(string levelNAME)
    {
        StartCoroutine(fadein(levelNAME));
    }
    public void FADOUT()
    {
        StartCoroutine(fadeout());
    }
    public IEnumerator fadein(string levelName)
    {
        CavasOfFadeing.gameObject.SetActive(true);
        fadeing.Play("fadein ");
        yield return new WaitForSeconds(0.7f);
        Application.LoadLevel(levelName);
        FADOUT();
    }
    public IEnumerator fadeout()
    {
        fadeing.Play("fadeout");
        yield return new WaitForSeconds(1f);
        CavasOfFadeing.gameObject.SetActive(false);
    }
    public void hf() { Debug.Log("josjvosfjvb");}
        #endregion
}