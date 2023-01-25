using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    // Start is called before the first frame update
    void Start()
    {
        GenerateColor();
        _randomTime = true;

    }

    public void GenerateColor()
    {
        int blueRandom = Random.Range(0, btns.Length);
        Debug.Log(blueRandom);
        count = 0;
        for (int i = 0; i < btns.Length; i++)
        {
            if (i == blueRandom)
            {
                btns[blueRandom].GetComponent<Image>().color = new Color32(22, 123, 221, 255);
                exportBTN = btns[blueRandom];
            }
            else
            {
                btns[i].GetComponent<Image>().color = new Color32(229, 40, 215, 255);
                exportRedBtns[count] = btns[i];
                count++;
            }
        }


    }

    private void Update()
    {
        //random seconds between 6-15
        if(_randomTime)
        {
            int RandomNumber = Random.Range(6, 16);
            _randomTime = false;
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
            Walk._shouldWalk = false;
            _walk.AddEventToBTN(exportBTN);
            _walk.AddEventRedBtns();

        }

    }

    IEnumerator CountTime(int RR)
    {
        while (_timecount < RR * 3)
        {
            _timecount += Time.deltaTime;
            yield return null;
        }

        _timecount = 0;
        _randomTime = true;
    }


}
