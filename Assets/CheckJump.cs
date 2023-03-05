using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckJump : MonoBehaviour
{
    private bool jumpAllow;
    private GameObject Player;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] float JumpSpeed;
    [SerializeField] LayerMask Ground;

    // Update is called once per frame
    void Update()
    {
        if (!ChangePlayer.PlayerGirl)
        {
            Player = GameObject.FindWithTag("PlayerB");
        }
        else
        {
            Player = GameObject.FindWithTag("PlayerG");

        }

        rb=Player.GetComponent<Rigidbody2D>();
        anim=Player.GetComponent<Animator>();
        Debug.DrawRay(Player.transform.position, Vector2.down, Color.black);
    }

    private void FixedUpdate()
    {
        if(jumpAllow)
        {
            rb.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            jumpAllow = false;
            anim.SetBool("Jump", false);

        }
    }

    public void CanJump()
    {
            
        if(Physics2D.Raycast(Player.transform.position, Vector2.down, 1f, Ground))
         {

                 jumpAllow = true;
                anim.SetBool("Jump", true);
                  
             
    
         }
        
            
        
    }

}
