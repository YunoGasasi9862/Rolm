using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkCount : MonoBehaviour
{
    private Text _count;

    private void Start()
    {
        _count= GetComponent<Text>();   
    }
    // Update is called once per frame
    void Update()
    {
        _count.text = Walk.walkCount.ToString("0");
    }
}
