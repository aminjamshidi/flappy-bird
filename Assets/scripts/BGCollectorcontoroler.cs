using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollectorcontoroler : MonoBehaviour
{
    #region private variables
    private GameObject[] backgrounds;
    private GameObject[] grounds;
    private float BGX;
    private float GRX;
    #endregion
    #region public variables
    #endregion
    #region private method
    private void Awake()
    {
        int i;
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        BGX = backgrounds[0].transform.position.x;
        GRX = grounds[0].transform.position.x;
        for (i = 1; i < backgrounds.Length; i++)
        {
            if (BGX < backgrounds[i].transform.position.x)
            {
                BGX = backgrounds[i].transform.position.x;
            }
        }
        for (i = 1; i < grounds.Length; i++)
        {
            if (GRX < grounds[i].transform.position.x)
            {
                GRX = grounds[i].transform.position.x;
            }
        }
    }
    #endregion
    #region public method
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Background")
        {
            Vector3 temp=col.transform.position;
            float width = BGX + ((BoxCollider2D)col).size.x;
            temp.x = width;
            col.transform.position = temp;
            BGX = temp.x;
        }
        else if (col.tag == "Ground")
        {
            Vector3 temp = col.transform.position;
            float width = GRX + ((BoxCollider2D)col).size.x;
            temp.x = width;
            col.transform.position = temp;
            GRX = temp.x;
        }
    }
    #endregion
}
