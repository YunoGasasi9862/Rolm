using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingsPanel : MonoBehaviour
{
    [SerializeField] GameObject panelPrefab;

  
    public void OpenSettingPanel()
    {
        panelPrefab.SetActive(true);
    }


    public void CloseSettingPanel()
    {
        panelPrefab.SetActive(false);
    }
}
