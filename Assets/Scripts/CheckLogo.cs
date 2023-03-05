using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLogo : MonoBehaviour
{
    [SerializeField] GameObject Redirect;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("logo"))
        {
             Redirect.SetActive(true);
        }
    }
}
