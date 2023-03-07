using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TimerAction
{
    START,
    PAUSE,
    RESUME,
    RESET,
    END,
    INTERVAL
}
public class TimerEvents
{
    private Dictionary<TimerAction, List<UnityAction>> TimerEventsDict = new Dictionary<TimerAction, List<UnityAction>>()
    {
        { TimerAction.START, new List<UnityAction>() },
        { TimerAction.PAUSE, new List<UnityAction>() },
        { TimerAction.RESUME, new List<UnityAction>() },
        { TimerAction.RESET, new List<UnityAction>() },
        { TimerAction.END, new List<UnityAction>() },
        { TimerAction.INTERVAL, new List<UnityAction>() }
    };

    public void AddAction(TimerAction timerAction, UnityAction action)
    {
        TimerEventsDict[timerAction].Add(action);
    }

    public void RemoveAction(TimerAction timerAction, UnityAction action)
    {
        TimerEventsDict[timerAction].Remove(action);
    }
    public void Clear(TimerAction timerAction)
    {
        TimerEventsDict[timerAction].Clear();
    }
    public void ClearAll()
    {
        foreach(var e in TimerEventsDict)
        {
            e.Value.Clear();
        }
    }
    public void InvokeAction(TimerAction timerAction)
    {
        TimerEventsDict[timerAction].ForEach(a=>a.Invoke());
    }

}
