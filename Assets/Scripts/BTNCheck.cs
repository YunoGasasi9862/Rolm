using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BTNCheck : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{

    public bool buttonPressed;
    private string currentTag;
    private Vector2 _BTNtransform;
    [SerializeField] Canvas canv;
    public static float factor = 1f;
    public static bool running = false;
    public static bool runForRed = false;
    private Vector2 _BorderTransform;
    private void Start()
    {

        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canv.transform, transform.position,
            canv.worldCamera, out _BTNtransform);

        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canv.transform, transform.parent.position,
            canv.worldCamera, out _BorderTransform);
        //IM GONNA CRY!!
        //it worked
        //uses the transformutility, converts it to screentopointreactang
        //makes use of canv.transform to get the bounds and transform
        //transform.position for current position
        //canv.worldcamera for changing the position coordinates

    }
    private void Update()
    {
      
      

        if (buttonPressed)
        {
            currentTag = transform.gameObject.tag;


            if (currentTag=="RBTN")
            {
                Walk.decrease = true;
                runForRed = true;
                Walk._shouldWalk = true;
                Walk.anim.SetBool("Walk", true);
            }
            else
            {
                runForRed = false;
                Walk._shouldWalk = true;


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
    public void OnDrag(PointerEventData data)
    {
        running = true;
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)
            canv.transform, data.position, canv.worldCamera, out position);

        //moving elements in Unity
        //requires canvas

      

         if(position.y < _BTNtransform.y+15 && position.y > _BTNtransform.y -15 && position.x > _BTNtransform.x - 200 && position.x<=_BTNtransform.x)
        {
            transform.parent.position = canv.transform.TransformPoint(position);

            factor = (Mathf.Abs(position.x - _BTNtransform.x) / 100.0f) + 1;
    
        }



        //this is the way you set position on canvas
    }

    public void OnEndDrag(PointerEventData data)
    {
        transform.parent.position = canv.transform.TransformPoint(_BorderTransform);
        transform.position = canv.transform.TransformPoint(_BTNtransform);
        running = false;
    }

}
