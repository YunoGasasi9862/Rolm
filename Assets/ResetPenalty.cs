using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPenalty : MonoBehaviour
{
    // Start is called before the first frame update
    private float _cameraWidth;
    [SerializeField] GameObject Logo;
    [SerializeField] GameObject Redirect;
    private bool _canResetPenalty = false;
    [SerializeField] GameObject WarningUI;
    private bool Disappear = false;
    private float Timer;

    void Start()
    {
        _cameraWidth = Camera.main.orthographicSize * Camera.main.aspect; //returns half the width
    

    }

    // Update is called once per frame
    void Update()
    {

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

            if (Timer > 3f)
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
            if (Logo.transform.position.x <= Camera.main.transform.position.x + _cameraWidth &&

             Logo.transform.position.x >= Camera.main.transform.position.x - _cameraWidth)
            {

                _canResetPenalty = true;

            }

        }
       
    }


    public void AllowResetting()
    {

        if(_canResetPenalty)
        {
            Redirect.SetActive(true);
            _canResetPenalty = false;
        }
    }
}
