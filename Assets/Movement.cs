using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject Player;
    private Rigidbody2D rb;
    private float _runningSpeed = 3f;
    private bool _btnRightPressed = false;
    private bool _btnLeftPressed = false;
    private SpriteRenderer sr;
    private Animator anim;
    private void Start()
    {
        Player = GameObject.FindWithTag("PlayerG") ? GameObject.FindWithTag("PlayerG") : GameObject.FindWithTag("PlayerB");
        rb=Player.GetComponent<Rigidbody2D>();
        sr=Player.GetComponent<SpriteRenderer>();
        anim=Player.GetComponent<Animator>();
    }

    private void Update()
    {
        Player = GameObject.FindWithTag("PlayerG") ? GameObject.FindWithTag("PlayerG") : GameObject.FindWithTag("PlayerB");

        
        if(LevelChecker.GameOver==false)
        {
            if (_btnRightPressed)
            {

                Player.transform.Translate(_runningSpeed * Time.deltaTime, 0, 0);
                sr.flipX = false;

            }

            if (_btnLeftPressed)
            {
                Player.transform.Translate(-_runningSpeed * Time.deltaTime, 0, 0);
                sr.flipX = true;

            }

            if (_btnLeftPressed || _btnRightPressed)
            {
                anim.SetBool("Run", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sliding"))
            {
                if (sr.flipX)
                {
                    rb.AddForce(-transform.right * 5f * Time.deltaTime, ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(transform.right * 5f * Time.deltaTime, ForceMode2D.Impulse);

                }

            }
        }
          
          
        

    }   

    
  

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Right")
        {


            _btnRightPressed = true;
         }
        else
        {
           _btnLeftPressed= true;

        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if (gameObject.name == "Right")
        {


            _btnRightPressed = false;

        }
        else
        {
            _btnLeftPressed = false;

        }

        anim.SetBool("Run", false);
        anim.SetBool("sliding", true);

    }
}
