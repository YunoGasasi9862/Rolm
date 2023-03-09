using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public static bool PlayerGirl=true;

    [SerializeField] GameObject PlayerG;
    [SerializeField] GameObject PlayerB;

    [SerializeField] GameObject SettingUI;

    public void ChangeToBoy()
    {
        if (!GameObject.FindWithTag("PlayerB"))
        {
            PlayerGirl = false;
            PlayerG.SetActive(false);
            PlayerB.SetActive(true);
            Vector3 newPos = PlayerG.transform.position;
            PlayerB.transform.position = newPos;
        }

        SettingUI.SetActive(false);
    }

    public void ChangeToGirl()
    {
        if(!GameObject.FindWithTag("PlayerG"))
        {
            PlayerGirl = true;
            PlayerG.SetActive(true);
            PlayerB.SetActive(false);
            Vector3 newPos = PlayerB.transform.position;
            PlayerG.transform.position = newPos;
        }

        SettingUI.SetActive(false);


    }
}
