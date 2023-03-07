using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EasyClockTime
{
    [SerializeField] public int Seconds;
    [SerializeField] public int Minutes;
    [SerializeField] public int Hours;

    public int InSeconds()
    {
        return Seconds + (Minutes * 60) + (Hours * 60 * 60);
    }
}
