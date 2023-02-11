using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPenalty : MonoBehaviour
{
    // Start is called before the first frame update
    private float _cameraWidth;
    [SerializeField] GameObject Logo;
    private bool _canResetPenalty = false;

    void Start()
    {
        _cameraWidth = Camera.main.orthographicSize * Camera.main.aspect; //returns half the width
    

    }

    // Update is called once per frame
    void Update()
    {
       /** if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit; //declaration of ray
          Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
            //getting ray Camera.Main.screenpointtoRay

            if(Physics.Raycast(ray, out hit))  //passes ray as target, and outputs into hit
            {
                if(hit.collider.tag=="logo")
                {
                    //play animation

                     
                    //reset Penalty
                    Walk.penaltyCount = 0;


                    //destroy gameobject
                    Destroy(gameObject);


                    //respawn logo again somewhere

                    LogoGenerator.isGenerated = false;






                }
            }
        }
       **/
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
            Debug.Log("Hello");
            _canResetPenalty = false;
        }
    }
}
