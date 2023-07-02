using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject buttons, scroller;
    private void Start()
    {
    }
    public void ExitApp()
    {
        Application.Quit();
        
    }
    public void OpenOptions()
    {
        buttons.SetActive(false); 
        scroller.SetActive(true);

    }
    public void CloseOptions()
    {
        buttons.SetActive(true);
        scroller.SetActive(false);

    }
}
