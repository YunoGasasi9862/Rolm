using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PenaltyText : MonoBehaviour
{
    public static Text penalty;
    private int _oldsteps;
    private float Timer;
    private void Start()
    {
        penalty = GetComponent<Text>();
    }

    void Update()
    {

        if (!BTNCheck.running)
        {
            penalty.text = Walk.penaltyCount.ToString("0");

        }
        else
        {

            if(Walk.decrease)
            {
                Timer += Time.deltaTime;
                if (Timer > .2f)
                {

                    _oldsteps = Walk.penaltyCount;
                    _oldsteps -= (int)BTNCheck.factor;
                    penalty.text = _oldsteps.ToString("0");
                    Walk.penaltyCount = _oldsteps;
                    Walk._walkingspeed = 100 * BTNCheck.factor;
                    Timer = 0f;

                }
                 
            }
                
            

        }
    }
}
