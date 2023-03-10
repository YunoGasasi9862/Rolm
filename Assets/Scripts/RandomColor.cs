using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour
{
    [SerializeField] Button[] btns=new Button[3];
    public static Button exportBTN;
    public static Button[] exportRedBtns = new Button[2];
    private float _timecount=0;
    private bool _randomTime = false;
    [SerializeField] Walk _walk;
    private int count = 0;
    private Animator Player;
    private int previousColor=-1;
    // Start is called before the first frame update
    void Start()
    {
        GenerateColor();
        _randomTime = true;

    }

    public void GenerateColor()
    {
        int blueRandom = Random.Range(0, btns.Length);
        while(blueRandom==previousColor)
        {
            blueRandom = Random.Range(0, btns.Length);
        }
        count = 0;
        for (int i = 0; i < btns.Length; i++)
        {
            if (i == blueRandom)
            {
                btns[blueRandom].GetComponent<Image>().color = new Color32(22, 123, 221, 255);
                btns[blueRandom].tag = "BTN";
                exportBTN = btns[blueRandom];
                previousColor = blueRandom;

            }
            else
            {
                btns[i].GetComponent<Image>().color = new Color32(229, 40, 215, 255);
                btns[i].tag = "RBTN";

                exportRedBtns[count] = btns[i];
                count++;
            }
        }


    }

    private void Update()
    {

        if (!ChangePlayer.PlayerGirl)
        {
            Player = GameObject.FindWithTag("PlayerB").GetComponent<Animator>();
           
        }
        else
        {
            Player = GameObject.FindWithTag("PlayerG").GetComponent<Animator>();

        }
        //random seconds between 6-15
        if (_randomTime)
        {
            int RandomNumber = Random.Range(2, 6);
           StartCoroutine(CountTime(RandomNumber));
            GenerateColor();

            if(Walk.trigger!=null)
            {
                Walk.trigger.triggers.RemoveRange(0, Walk.trigger.triggers.Count);

            }
            if(Walk.trigger2!=null)
            {
                Walk.trigger2.triggers.RemoveRange(0, Walk.trigger2.triggers.Count);

            }

            if (Walk.trigger3 != null)
            {
                Walk.trigger3.triggers.RemoveRange(0, Walk.trigger.triggers.Count);

            }
            if (Walk.trigger4 != null)
            {
                Walk.trigger3.triggers.RemoveRange(0, Walk.trigger2.triggers.Count);

            }



            _walk.AddEventToBTN(exportBTN);

            _walk.AddEventRedBtns();
            Walk._shouldWalk = false;
            Player.SetBool("Walk", false);
            Walk.decrease = false;

          


            _randomTime = false;

        }

    }

    IEnumerator CountTime(int RR)
    {
        while (_timecount < RR)
        {
            _timecount += Time.deltaTime;
            yield return null;
        }

        _timecount = 0;
        _randomTime = true;
    }


}
