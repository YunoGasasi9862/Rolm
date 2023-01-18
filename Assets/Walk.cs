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
            rb.AddForce(Vector2.right * 1000f * Time.deltaTime, ForceMode2D.Force);

        });
        trigger.triggers.Add(entry);

        EventTrigger trigger2 = g.GetComponent<EventTrigger>();
        EventTrigger.Entry entry2= new EventTrigger.Entry();
        entry2.eventID= EventTriggerType.PointerUp;
        entry2.callback.AddListener((ReleaseFunc) =>
        {
            anim.SetBool("Walk", false);
            Vector2 velocity = rb.velocity;
            velocity.x = 0f;
            rb.velocity = velocity;


        });

        trigger2.triggers.Add(entry2);
    }
}
