using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PenaltyText : MonoBehaviour
{
    private Text penalty;

    private void Start()
    {
        penalty = GetComponent<Text>();
    }

    void Update()
    {
        penalty.text = Walk.penaltyCount.ToString("0");
    }
}
