using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkCount : MonoBehaviour
{
    private Text _count;
    private int _oldsteps;
    private void Start()
    {
        _count= GetComponent<Text>();   
    }
    // Update is called once per frame
    void Update()
    {
        if(!BTNCheck.running)
        {
            _count.text = Walk.walkCount.ToString("0");

        }
        else
        {

            if(!Walk.decrease)
            {
                _oldsteps = Walk.walkCount;
                _oldsteps += (int)BTNCheck.factor;
                _count.text = _oldsteps.ToString("0");
                Walk.walkCount = _oldsteps;
                Walk._walkingspeed = 100 * BTNCheck.factor / 2;
            }
           
        }
    }
}
