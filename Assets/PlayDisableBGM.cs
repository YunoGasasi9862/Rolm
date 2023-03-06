using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayDisableBGM : MonoBehaviour
{
    [SerializeField] AudioSource _bgm;
    [SerializeField] Toggle _bgmToggle;
    private bool once = false;
    void Start()
    {

        PlayBGM();
    }

    private void Update()
    {
        if (_bgmToggle.isOn && once)
        {
            PlayBGM();
        }
        if(!_bgmToggle.isOn && !once)
        {
            StopBGM();
        }
    }


    void PlayBGM()
    {
        _bgm.Play();
        once = false;
    }

    void StopBGM()
    {
        _bgm.Stop();
        once = true;
    }

}
