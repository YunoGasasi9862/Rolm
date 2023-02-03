using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PenaltyText : MonoBehaviour
{
    private Text penalty;
    private int _oldsteps;
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
                _oldsteps = Walk.penaltyCount;
                _oldsteps -= (int)BTNCheck.factor;
                penalty.text = _oldsteps.ToString("0");
                Walk.penaltyCount = _oldsteps;
                Walk._walkingspeed = 100 * BTNCheck.factor / 2;
            }
                
            

        }
    }
}
