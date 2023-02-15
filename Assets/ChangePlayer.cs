using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public static bool PlayerGirl=true;

    [SerializeField] GameObject PlayerG;
    [SerializeField] GameObject PlayerB;

    public void ChangeToBoy()
    {
        PlayerGirl = false;
        PlayerG.SetActive(false);
        PlayerB.SetActive(true);
        Vector3 newPos = PlayerG.transform.position;
        PlayerB.transform.position = newPos;
       
    }

    public void ChangeToGirl()
    {
        PlayerGirl = true;
        PlayerG.SetActive(true);
        PlayerB.SetActive(false);
        Vector3 newPos = PlayerB.transform.position;
        PlayerG.transform.position = newPos;

    }
}
