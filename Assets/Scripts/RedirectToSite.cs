using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectToSite : MonoBehaviour
{
    [SerializeField] GameObject Redirect;
    [SerializeField] GameObject[] Logo;


    private void Update()
    {
        Logo = GameObject.FindGameObjectsWithTag("logo");

    }
    public void TaketoSite()
    {

        Application.OpenURL("https://rolm.io/shop");
        Redirect.SetActive(false);
        Walk.penaltyCount = 0;
        for (int i = 0; i < Logo.Length; i++)
        {
            Destroy(Logo[i]);
        }
     
        Invoke("SetToFalse",.5f);



    }

    public void SetToFalse()
    {
        LogoGenerator.isGenerated = false;

    }
}
