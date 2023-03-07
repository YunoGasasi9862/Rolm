using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum DisplayMode
{
    OneNumber,
    MMSS,
    HHMMSS,
    HHMM
}
public class EasyClockTimerBehaviour : MonoBehaviour
{
    [SerializeField] public Text TimerText;
    [SerializeField] public bool Ascending = true;
    [SerializeField] public EasyClockTime StartAt;
    [SerializeField] public EasyClockTimeEnd EndAt;
    [SerializeField] public EasyClockTime Interval;
    [SerializeField] public int DecimalsAfterPoint = 0;
    [SerializeField] public int NumbersBeforePoint = 0;
    [SerializeField] public DisplayMode Mode;

    [SerializeField] public string TimerEndedText;
    [SerializeField] public string TimerPausedText;

    [SerializeField] public Color TimerColor = Color.black;
    [SerializeField] public Color TimerEndedColor = Color.black;
    [SerializeField] public Color TimerPausedColor = Color.black;
    [SerializeField] public bool StartAutomatically = false;
    private int _startTime;
    private int _endTime;
    private int _nextInterval;
    private bool _isStarted = false;
    private bool _isPaused = false;
    private bool _timerFinished = false;
    private double _actualTime;

    private TimerEvents _timerEvents = new TimerEvents();

    // Start is called before the first frame update
    void Start()
    {
        _startTime = StartAt.InSeconds();
        _endTime = EndAt.InSeconds();

        _isStarted = StartAutomatically;
        _actualTime = _startTime;
        TimerText.color = TimerColor;
        InitInterval();
    }

    void InitInterval()
    {
        if (Ascending)
        {
            _nextInterval = _startTime + Interval.InSeconds();
        }
        else
        {
            _nextInterval = _startTime - Interval.InSeconds();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStarted)
        {

            if (!_timerFinished)
            {
                if (!_isPaused)
                {
                    _actualTime = Ascending ? _actualTime + Time.deltaTime : _actualTime - Time.deltaTime;
                   
                    IntervalCheck();
                    if (!EndAt.NeverEnding)
                    {
                        if (Ascending)
                        {
                            if (_actualTime >= _endTime)
                            {
                                TimerEnded();
                            }
                        }
                        else
                        {
                            if (_actualTime <= _endTime)
                            {
                                TimerEnded();
                            }
                        }
                    }
                    _actualTime = TimeValidation(_actualTime);
                    TimerText.text = FormatClockTimerText(_actualTime);
                }
            }
        }
    }

    void IntervalCheck()
    {
        if (Ascending)
        {
            if (_actualTime >= _nextInterval)
            {
                _nextInterval = _nextInterval + Interval.InSeconds();
                _timerEvents.InvokeAction(TimerAction.INTERVAL);
            }
        }
        else
        {
            if (_actualTime <= _nextInterval)
            {
                _nextInterval = _nextInterval - Interval.InSeconds();
                _timerEvents.InvokeAction(TimerAction.INTERVAL);
            }
        }
    }

    double TimeValidation(double time)
    {
        if (time < 0)
        {
            time = 86400;
        }
        else if (time > (86400)) // One day
        {
            time = 0;
        }
        return time;
    }

    public void StartTimer()
    {
        _isStarted = true;
        _timerEvents.InvokeAction(TimerAction.START);
    }
    public void PauseTimer()
    {
        _isPaused = true;
        if (!String.IsNullOrEmpty(TimerPausedText))
        {
            TimerText.text = TimerPausedText;
        }
        TimerText.color = TimerPausedColor;
        _timerEvents.InvokeAction(TimerAction.PAUSE);
    }

    public void ResumeTimer()
    {
        _isPaused = false;
        TimerText.color = TimerColor;
        _timerEvents.InvokeAction(TimerAction.RESUME);
    }

    public void ResetTimer()
    {
        _actualTime = _startTime;
        _timerFinished = false;
        TimerText.text = FormatClockTimerText(_actualTime);
        TimerText.color = TimerColor;
        _timerEvents.InvokeAction(TimerAction.RESET);
    }


    private void TimerEnded()
    {
        _timerFinished = true;
        _actualTime = _endTime;
        _timerEvents.InvokeAction(TimerAction.END);
    }


    private string FormatClockTimerText(double time)
    {
        switch (Mode)
        {
            case DisplayMode.OneNumber:
                return _timerFinished ? TimerEndedFormat(time) : String.Format(OneNumberFormat(), time);
            case DisplayMode.MMSS:
                return _timerFinished ? TimerEndedFormat(time) : MMSSFormat(time);
            case DisplayMode.HHMMSS:
                return _timerFinished ? TimerEndedFormat(time) : HHMMSSFormat(time);
            case DisplayMode.HHMM:
                return _timerFinished ? TimerEndedFormat(time) : HHMMFormat(time);
        }
        return time.ToString();
    }
    private string TimerEndedFormat(double time)
    {
        string s = time.ToString();
        if (!String.IsNullOrEmpty(TimerEndedText))
        {
            s = TimerEndedText;
        }
        TimerText.color = TimerEndedColor;
        return s;
    }
    private string OneNumberFormat()
    {
        string s = "{0:0}";
        if (DecimalsAfterPoint > 0)
        {
            string numberOfDec = "";
            string numbersBefore = "0";
            for (int i = 0; i < DecimalsAfterPoint; i++)
            {
                numberOfDec += "0";
            }
            for (int i = 1; i < NumbersBeforePoint; i++)
            {
                numbersBefore += "0";
            }
            s = "{" + $"0:{numbersBefore}.{numberOfDec}" + "}";
        }
        return s;
    }

    private string HHMMSSFormat(double time)
    {
        string s = "";
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        s = timeSpan.ToString();
        int indexOfPoint = s.IndexOf('.');
        if (indexOfPoint > 0)
        {
            s = s.Substring(0, indexOfPoint);
        }
        return s;
    }
    private string MMSSFormat(double time)
    {
        string s = "";
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        s = timeSpan.ToString();
        int indexOfPoint = s.IndexOf('.');
        int indexOfTwoPoints = s.IndexOf(':');
        if (indexOfPoint > 0 && indexOfTwoPoints > 0)
        {
            s = s.Substring(0, indexOfPoint);
            s = s.Substring(indexOfTwoPoints + 1);
        }
        return s;
    }

    private string HHMMFormat(double time)
    {
        string s = "";
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        s = timeSpan.ToString();
        s = s.Substring(0, 5);

        return s;
    }

    public void AttachActionToTimerEvent(TimerAction timerAction, UnityAction action)
    {
        _timerEvents.AddAction(timerAction, action);
    }

    public void DettachActionFromTimerEvent(TimerAction timerAction, UnityAction action)
    {
        _timerEvents.RemoveAction(timerAction, action);
    }
    public void DettachAllActionsFromTimerEvent(TimerAction timerAction)
    {
        _timerEvents.Clear(timerAction);
    }
    public void DettachAllActions()
    {
        _timerEvents.ClearAll();
    }
}
