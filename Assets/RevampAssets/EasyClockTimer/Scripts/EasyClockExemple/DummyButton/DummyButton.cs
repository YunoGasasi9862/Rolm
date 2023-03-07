using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is only an example class on how to use each Timer/Clock Actions. (Start, Pause, Reset)
public class DummyButton : MonoBehaviour
{
    public EasyClockTimerBehaviour EasyClock;
    public void OnStartButtonClick()
    {
        EasyClock.StartTimer();
    }
    public void OnResumedButtonClick()
    {
        EasyClock.ResumeTimer();
    }
    public void OnPauseButtonClick()
    {
        EasyClock.PauseTimer();
    }
    public void OnResetButtonClick()
    {
        EasyClock.ResetTimer();
    }
}
