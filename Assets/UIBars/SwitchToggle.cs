using UnityEngine ;
using UnityEngine.UI ;
using DG.Tweening ;

public class SwitchToggle : MonoBehaviour {

    [SerializeField] RectTransform uiHandleRT;
    [SerializeField] Color backgroundColorActive;
    [SerializeField] Color handleColorActive;

    Color backgroundDefaultColor, handleDefaultColor;

    Image backgroundDefaultImage, handleDefaultImage;

    Toggle toggle; //reference

    Vector2 handlePosition;
   
    private void Awake()
    {
        toggle= GetComponent<Toggle>();

        handlePosition = uiHandleRT.anchoredPosition; //gets the recttransform anchoredpos

        backgroundDefaultImage= uiHandleRT.parent.GetComponent<Image>();
        handleDefaultImage= uiHandleRT.GetComponent<Image>();

        backgroundDefaultColor = backgroundDefaultImage.color;
        handleDefaultColor = handleDefaultImage.color;

        toggle.onValueChanged.AddListener(onSwitchChange); //adds listener to the toggle, that's all it does
        //not calling the function yet, just adding listener

        if(toggle.isOn)
        {
            onSwitchChange(true);  //if its turned on, the toggle, calls the function, and change the position of the handle
        }

    }

   

    void onSwitchChange(bool on)
    {
        //shifts to left or right
       // uiHandleRT.anchoredPosition = on ? handlePosition * -1 : handlePosition;
       uiHandleRT.DOAnchorPos(on ? handlePosition * -1 : handlePosition, .4f).SetEase(Ease.InOutBack);
        // backgroundDefaultImage.color = on ? backgroundColorActive : backgroundDefaultColor;

        backgroundDefaultImage.DOColor(on ? backgroundColorActive : backgroundDefaultColor, .6f).SetEase(Ease.InOutBack);


        //  handleDefaultImage.color = on ? handleColorActive : handleDefaultColor;
        handleDefaultImage.DOColor(on ? handleColorActive : handleDefaultColor, .6f).SetEase(Ease.InOutBack);




    }


}
