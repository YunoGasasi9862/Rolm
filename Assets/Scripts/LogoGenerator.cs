using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoGenerator : MonoBehaviour
{
    [SerializeField] GameObject Logo;
    [SerializeField] int NumberOfLogos;
    [SerializeField] float HeightOfLogo;
    private float width, height;
    // Update is called once per frame

    private void Start()
    {
        height =2f *  Camera.main.orthographicSize; //gives the full height
        width = height * Camera.main.aspect;//gives the width


        //generating all the logos once
        float distanceBetweenLogos = width / NumberOfLogos;
        for (int i=0; i<NumberOfLogos; i++)
        {

            Vector2 LogoPos = new Vector2(Logo.transform.position.x + (distanceBetweenLogos * (float)(i-1.5)), Logo.transform.position.y + HeightOfLogo);

           GameObject _logo= Instantiate(Logo, LogoPos, Logo.transform.rotation);
            _logo.GetComponent<SpriteRenderer>().enabled = false;

        }

    }
   

  
}
