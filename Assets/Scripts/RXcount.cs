using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RXcount : MonoBehaviour
{
    private Text _RX;
    float _RXValue;
    void Start()
    {
        _RX= GetComponent<Text>();
    }

    
    void Update()
    {
        _RXValue = Walk.walkCount / 1000.0f;
        _RX.text = _RXValue.ToString("0.000");
    }
}
