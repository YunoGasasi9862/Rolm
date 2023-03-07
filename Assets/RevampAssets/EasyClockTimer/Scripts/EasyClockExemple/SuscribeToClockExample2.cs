using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuscribeToClockExample2 : MonoBehaviour
{
    // Another way to do the first example would be to use the Interval event instead of the Ending event.
    // This way the timer does not reset.
    public Text CounterText;
    // This is the counter that we will increment on each timer end.
    private int _counter = 0;
    public EasyClockTimerBehaviour EasyClockReference;
    private void Start()
    {
        CounterText.text = _counter.ToString();
        EasyClockReference.AttachActionToTimerEvent(TimerAction.INTERVAL, FunctionThatIWantToExecuteWhenTimerEnd);
    }

    // Note that an action is passed to the timer so it cannot contains arguments.
    // Since we are suscribing to this easy clock ending event, this action will get called each time the time ends.
    void FunctionThatIWantToExecuteWhenTimerEnd()
    {
        _counter++;
        CounterText.text = _counter.ToString();
    }
}
