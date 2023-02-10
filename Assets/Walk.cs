using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Walk : MonoBehaviour
{
    private bool once;
    public static Animator anim;
    private Rigidbody2D rb;
    public static bool _shouldWalk;
   public static float _walkingspeed=100;
    [SerializeField] RandomColor _Rc;
    public static EventTrigger trigger, trigger2;
    public static EventTrigger trigger3, trigger4;
    public static int walkCount=0;
    public static int penaltyCount=0;
    public static bool decrease = false;
    public static float _penaltyCountTime = 0;
    private bool redOnce = false;
    public static float vibration;
    [SerializeField] GameObject PenaltyUI;
    float _timer;

    private void Awake()
    {
        Application.targetFrameRate = 120;

    }
    private void Start()
    {
        anim= GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
        PenaltyUI.SetActive(false);
    }

    void Update()
    {

        if(RandomColor.exportBTN!=null && !once)
        {
            AddEventToBTN(RandomColor.exportBTN);
            once = true;

        }

       if(RandomColor.exportRedBtns[0]!=null && RandomColor.exportRedBtns[1] != null && !redOnce)
        {
           AddEventRedBtns();
            redOnce = true;
        }

        if (decrease)
        {
            _timer+= Time.deltaTime;
            if (_timer >= .5f)
            {
                PenaltyUI.SetActive(true);
            }

            vibration += Time.deltaTime;

            if(vibration>10f)
            {
                Handheld.Vibrate();
            }



            _penaltyCountTime += Time.deltaTime;
            if (_penaltyCountTime > .9f)
            {
                penaltyCount--;
                _penaltyCountTime = 0;
                _timer = 0;

            }
        }

        if(BTNCheck.running)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
           

        }




    }

    public void AddEventToBTN(Button g)
    {
         if(trigger3!=null)
         {
             trigger3.triggers.RemoveRange(0, trigger3.triggers.Count);

         }

         if(trigger4!=null)
         {
             trigger4.triggers.RemoveRange(0, trigger4.triggers.Count);

         }

        if (trigger != null)
        {
            trigger.triggers.RemoveRange(0, trigger.triggers.Count);

        }

        if (trigger2 != null)
        {
            trigger2.triggers.RemoveRange(0, trigger2.triggers.Count);

        }


        trigger = g.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((HoldFunc) =>
        {
            //call a fucntion or write statements

            anim.SetBool("Walk", true);
            decrease = false;
            _shouldWalk = true;

        });
        trigger.triggers.Add(entry);

         trigger2 = g.GetComponent<EventTrigger>();
        EventTrigger.Entry entry2= new EventTrigger.Entry();
        entry2.eventID= EventTriggerType.PointerUp;
        entry2.callback.AddListener((ReleaseFunc) =>
        {
            anim.SetBool("Walk", false);
            _shouldWalk = false;
            _Rc.GenerateColor();
            decrease = false;



            AddEventToBTN(RandomColor.exportBTN);


            AddEventRedBtns();




        });

        trigger2.triggers.Add(entry2);

        AddEventRedBtns();

    

    }

    public void AddEventRedBtns()
    {

        //RedBTNS
        for (int i = 0; i < RandomColor.exportRedBtns.Length; i++)
        {
            trigger3 = RandomColor.exportRedBtns[i].GetComponent<EventTrigger>();
            EventTrigger.Entry entry3 = new EventTrigger.Entry();
            entry3.eventID = EventTriggerType.PointerDown;
            entry3.callback.AddListener((PenaltyHold) =>
            {
               
                anim.SetBool("Walk", true);

                _shouldWalk = true;
                decrease = true;
               
             
            });
            trigger3.triggers.Add(entry3);
            trigger4 = RandomColor.exportRedBtns[i].GetComponent<EventTrigger>();
            EventTrigger.Entry entry4 = new EventTrigger.Entry();
            entry4.eventID = EventTriggerType.PointerUp;
            entry4.callback.AddListener((PenaltyRelease) =>
            {
                anim.SetBool("Walk", false);
                _shouldWalk = false;
                decrease = false;
                vibration = 0;

            });

          
            trigger4.triggers.Add(entry4);
        }
    }

    private void FixedUpdate()
    {

        if (_shouldWalk)
        {
            if (!BTNCheck.running)
            {
                _walkingspeed = 100.0f;
                rb.velocity = new Vector2(_walkingspeed * Time.deltaTime, 0f);

            }
            else
            {

                if(BTNCheck.runForRed || BTNCheck.running)
                {
                    rb.velocity = new Vector2(_walkingspeed * Time.deltaTime, 0f);

                }

            }

        }
        else
        {
            if(!BTNCheck.runForRed)
            {
                Vector2 velocity = rb.velocity;
                velocity.x = 0f;
                rb.velocity = velocity;
            }
             
           
       
        }

        if(!_shouldWalk)
        {
            Vector2 velocity = rb.velocity;
            velocity.x = 0f;
            rb.velocity = velocity;
        }
    }

    public void StepCount()
    {
        if(!BTNCheck.running && !BTNCheck.runForRed)
        {
             walkCount++;

        }
      
    }
}
