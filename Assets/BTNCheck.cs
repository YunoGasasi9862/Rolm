using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BTNCheck : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool buttonPressed;
    private string currentTag;
 
    private void Update()
    {
      
      

        if (buttonPressed)
        {
            currentTag = transform.gameObject.tag;


            if (currentTag=="RBTN")
            {
                Walk.decrease = true;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;

    }
}
