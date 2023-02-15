using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject Player;

   
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

        if (Player!=null)
        {
            if (transform.position.x < Player.transform.position.x)
            {
                transform.position = new Vector3(Player.transform.position.x, transform.position.y, -10);
            }
        }
       
    }
}
