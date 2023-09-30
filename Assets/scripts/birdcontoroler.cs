using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class birdcontoroler : MonoBehaviour
{
    #region public variables
    public gameplay ll;
    public int currentscore;
    public static birdcontoroler birdobject;
    public Button flapButton;
    public Animator flaping_anima;
    public Rigidbody2D rigidbody;
    public  bool FlagLife;
    public AudioSource audiosource;
    public AudioClip fly, dead, point;
    #endregion
    #region private variables
    private bool FlagFlap;
    [SerializeField]private float veerticalSpeed;
    [SerializeField]private float horizontalSpeed;
    #endregion
    #region public method
    public float  GivePosionToCamera()
    {
        return transform.position.x;
    }
    #endregion
    #region private method
    private void Awake()
    {
        if (birdobject == null) { birdobject = this; }
        FlagLife = true;
        currentscore = 0;
        flapButton.onClick.AddListener(() => ChangeFlapMoodToTrue());
        SetCameraOffset();
    }
    private void Start()
    {
        ll = GameObject.FindObjectOfType<gameplay>();
    }
    private void FixedUpdate()
    {
        if (FlagLife)
        {
            movingStright();
            flaping();
        }
        rotating_bird();
    }

    private void rotating_bird()
    {
        if (rigidbody.velocity.y >= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angel = Mathf.Lerp(0, -90, -rigidbody.velocity.y / 10);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    private void movingStright()
    {
        if (FlagLife)
        {
            Vector3 temp = transform.position;
            temp += new Vector3(veerticalSpeed * Time.deltaTime, 0, 0);
            transform.position = temp;
        }
    }

    private void flaping()
    {
        if (FlagFlap)
        {
            FlagFlap = false;
            rigidbody.velocity = new Vector2(0, horizontalSpeed);
            flaping_anima.SetTrigger("flap");
            audiosource.PlayOneShot(fly);

        }
    }
    private void ChangeFlapMoodToTrue()
    {
        FlagFlap = true;

    }
    private void SetCameraOffset()
    {
        cameracontoroler.OffSetX = (Camera.main.transform.position.x - transform.position.x);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (FlagLife)
        {
            if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Pipe")
            {
                FlagLife = false;
                audiosource.PlayOneShot(dead);
                flaping_anima.SetTrigger("dead");
                ll.ShowDeadMood(currentscore);
                //gameplay.instance.ShowDeadMood(currentscore);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PipeHolder")
        {
            currentscore++;
            audiosource.PlayOneShot(point);
            ll.ShowDeadMood(currentscore);
            //gameplay.instance.SetCurrentScore(currentscore);
        }
    }
    #endregion
}
