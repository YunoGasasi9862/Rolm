using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectToSite : MonoBehaviour
{
    [SerializeField] GameObject Redirect;
    [SerializeField] GameObject Logo;

    private void Start()
    {
        Logo = GameObject.FindWithTag("logo");
    }
    public void TaketoSite()
    {

        Application.OpenURL("https://rolm.io/shop");
        Redirect.SetActive(false);
        Walk.penaltyCount = 0;
        Destroy(Logo);
       
    }
}
