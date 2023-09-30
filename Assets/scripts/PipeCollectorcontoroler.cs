using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollectorcontoroler : MonoBehaviour
{
    #region public variables
    #endregion
    #region private variables
    private GameObject[] Pipes;
    private float PIX = 34.5f;
    #endregion
    #region public method
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PipeHolder")
        {
            Vector3 temp = col.transform.position;
            temp.x = PIX + 1.5f;
            temp.y = Random.Range(1f, -2f);
            col.transform.position = temp;
            PIX = temp.x;
        }
    }
    #endregion
    #region private method
    private void Awake()
    {
        int i;
        Pipes = GameObject.FindGameObjectsWithTag("PipeHolder");
        for (i = 0; i < Pipes.Length; i++)
        {
            Vector3 keeper = Pipes[i].transform.position;
            keeper.y = Random.Range(1f, -2f);
            Pipes[i].transform.position = keeper;
        }
    }
    private void Start()
    {
        InvokeRepeating("SetPIX",5f,7f);
    }
    private void SetPIX()
    {
        PIX += Random.Range(3f, 10f);
    }
    #endregion
}
