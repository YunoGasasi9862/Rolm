using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject Player;
   

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < Player.transform.position.x)
        {
            transform.position = new Vector3(Player.transform.position.x, transform.position.y,-10);
        }
    }
}
