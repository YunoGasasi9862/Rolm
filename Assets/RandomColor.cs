using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour
{
    [SerializeField] Button[] btns=new Button[3];
    public static Button exportBTN;

    // Start is called before the first frame update
    void Start()
    {
        int blueRandom = Random.Range(0, btns.Length);
        for(int i=0; i<btns.Length; i++)
        {
            if(i==blueRandom)
            {
                btns[i].GetComponent<Image>().color = new Color32(22, 123, 221, 255);
                exportBTN=btns[i];
            }
            else
            {
                btns[i].GetComponent<Image>().color = new Color32(229, 40, 215, 255);

            }
        }
    }

   
}
