using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkCount : MonoBehaviour
{
    public static Text _count;
    private int _oldsteps;
    private float Timer = 0;
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
                 Timer += Time.deltaTime;
                if(Timer>.2f)
                {
                    _oldsteps = Walk.walkCount;
                    _oldsteps += (int)BTNCheck.factor;
                    _count.text = _oldsteps.ToString("0");
                    Walk.walkCount = _oldsteps;
                    Walk._walkingspeed = 100 * BTNCheck.factor;
                    Timer = 0f;
                }
                
            }
           
        }

    }
}
