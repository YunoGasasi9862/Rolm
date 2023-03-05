using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDisableBGM : MonoBehaviour
{
    [SerializeField] AudioSource _bgm;
    void Start()
    {
        PlayBGM();
    }



    void PlayBGM()
    {
        _bgm.Play();

    }

    void StopBGM()
    {
        _bgm.Stop();
    }

}
