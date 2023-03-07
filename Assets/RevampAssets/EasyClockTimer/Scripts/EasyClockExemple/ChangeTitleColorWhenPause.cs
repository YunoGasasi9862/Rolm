using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTitleColorWhenPause : MonoBehaviour
{
    private Text TitleText;
    private List<EasyClockTimerBehaviour> easyClockTimerBehavioursCollection = new List<EasyClockTimerBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        // Using Linq to retrieve the EasyClockTimerBahaviour Component scripts from the game objects with tag EasyClockTimer.
        List<GameObject> gameObjects = GameObject.FindGameObjectsWithTag("EasyClockTimer").ToList();
        easyClockTimerBehavioursCollection = gameObjects.Select(go =>go.GetComponent<EasyClockTimerBehaviour>()).ToList();

        easyClockTimerBehavioursCollection.ForEach((x)=> 
        {
            x.AttachActionToTimerEvent(TimerAction.PAUSE, ChangeTitleColorToYellow);
            x.AttachActionToTimerEvent(TimerAction.RESUME, ChangeTitleColorToRed);
        });

        TitleText = GetComponent<Text>();
    }

    void ChangeTitleColorToYellow()
    {
        TitleText.color = Color.yellow;
    }

    void ChangeTitleColorToRed()
    {
        TitleText.color = Color.red;
    }
}
