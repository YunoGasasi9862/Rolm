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
    private bool _shouldWalk;
    [SerializeField] float _walkingspeed;
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

    private void AddEventToBTN(Button g)
    {
  

        EventTrigger trigger = g.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((HoldFunc) =>
        {
            anim.SetBool("Walk", true);
            _shouldWalk = true;

        });
        trigger.triggers.Add(entry);

        EventTrigger trigger2 = g.GetComponent<EventTrigger>();
        EventTrigger.Entry entry2= new EventTrigger.Entry();
        entry2.eventID= EventTriggerType.PointerUp;
        entry2.callback.AddListener((ReleaseFunc) =>
        {
            anim.SetBool("Walk", false);
            _shouldWalk = false;
          


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
