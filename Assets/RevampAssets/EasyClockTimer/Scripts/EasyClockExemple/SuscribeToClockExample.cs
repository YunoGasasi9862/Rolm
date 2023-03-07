using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuscribeToClockExample : MonoBehaviour
{
    public Text CounterText;
    // This is the counter that we will increment on each timer end.
    private int _counter = 0;
    // You need a reference to the EasyClockTimerBehaviour to attach a function. 
    // As we do here, you can also use the EasyClockReference to play around with the easy clock functions in the action your passing
    public EasyClockTimerBehaviour EasyClockReference;
    private void Start()
    {
        CounterText.text = _counter.ToString();
        EasyClockReference.AttachActionToTimerEvent(TimerAction.END, FunctionThatIWantToExecuteWhenTimerEnd);
    }

    // Note that an action is passed to the timer so it cannot contains arguments.
    // Since we are suscribing to this easy clock ending event, this action will get called each time the time ends.
    void FunctionThatIWantToExecuteWhenTimerEnd()
    {
        // Use the EasyClockReference to reset the timer when it ends.
        EasyClockReference.ResetTimer();
        _counter++;
        CounterText.text = _counter.ToString();
    }



}
