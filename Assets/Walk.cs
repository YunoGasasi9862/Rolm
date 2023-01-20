using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Walk : MonoBehaviour
{
    private bool once;
    private Animator anim;
    private Rigidbody2D rb;
    public static bool _shouldWalk;
    [SerializeField] float _walkingspeed;
    [SerializeField] RandomColor _Rc;
    public static EventTrigger trigger, trigger2; 
    private void Start()
    {
        anim= GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if(RandomColor.exportBTN!=null && !once)
        {
            AddEventToBTN(RandomColor.exportBTN);
            once = true;

        }
    }

    public void AddEventToBTN(Button g)
    {
  

        trigger = g.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((HoldFunc) =>
        {
            //call a fucntion or write statements
            anim.SetBool("Walk", true);
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
            trigger.triggers.RemoveRange(0, trigger.triggers.Count);
            trigger2.triggers.RemoveRange(0, trigger2.triggers.Count);

            AddEventToBTN(RandomColor.exportBTN);



        });

        trigger2.triggers.Add(entry2);
    }

    private void FixedUpdate()
    {
        if(_shouldWalk)
        {
            rb.velocity = new Vector2(_walkingspeed * Time.deltaTime, 0f);

        }
        else
        {
            Vector2 velocity = rb.velocity;
            velocity.x = 0f;
            rb.velocity = velocity;
        }
    }
}
