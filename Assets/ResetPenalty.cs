using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPenalty : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit; //declaration of ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
    }
}
