using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPenalty : MonoBehaviour
{
    // Start is called before the first frame update
    private float _cameraWidth;
    [SerializeField] GameObject Logo;
    private bool takeflash = false;
    [SerializeField] GameObject WarningUI;
    private bool Disappear = false;
    private float Timer;
    private GameObject Player;
    private bool once = true;
   
    void Start()
    {
        _cameraWidth = Camera.main.orthographicSize * Camera.main.aspect; //returns half the width
    

    }

    // Update is called once per frame
    void Update()
    {
           if (!ChangePlayer.PlayerGirl)
            {
                Player = GameObject.FindWithTag("PlayerB");
            }
            else
            {
                Player = GameObject.FindWithTag("PlayerG");

            }
        
       


        if (Input.GetMouseButtonDown(0))  //for warning!
        {
            RaycastHit rayCH;  //for storing the ray value
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out rayCH))
            {
                if (rayCH.collider.tag == "logo")
                {
                    WarningUI.SetActive(true);
                    Disappear = true;

                }

            }

        }

        if (Disappear)
        {
            Timer += Time.deltaTime;

            if (Timer > 2f)
            {
                WarningUI.SetActive(false);
                Disappear = false;
                Timer = 0f;
            }
        }


        if (Logo == null)
        {
            Logo = GameObject.FindWithTag("logo");
        }
        else
        {
            /**   if (Logo.transform.position.x <= Camera.main.transform.position.x + _cameraWidth &&

                Logo.transform.position.x >= Camera.main.transform.position.x - _cameraWidth)
               {

                   _canResetPenalty = true;

               }
            **/
            //play animation
            if(once)
            {
                takeflash = true;

            }


            //check the sprite if it overlaps the logo


            if (Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Flash") &&Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime>.7f)
            {
                Player.GetComponent<Animator>().SetBool("Flash", false);
                once = false;
            }

        }
       
    }


    public void AllowResetting()
    {

        if(takeflash)
        {
            Player.GetComponent<Animator>().SetBool("Flash", true);

            once = true;
            takeflash = false;
        }
    }

    
}
