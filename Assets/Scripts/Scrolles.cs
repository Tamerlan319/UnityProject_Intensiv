using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrolles : MonoBehaviour
{
    public GameObject scrolles, buttons;
    Text text;
    public Scrollbar scroll;
    float Value = 0;
    private void Start()
    {
        Value = PlayerPrefs.GetFloat("SavedSound");
        text = scrolles.GetComponent<Text>();
        scroll.value = Value;
    }
    public void OnChanged()
    {
        Value = scroll.value;
    }
    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("SavedSound", Value);
        PlayerPrefs.Save();
        scrolles.SetActive(false);
        buttons.SetActive(true);
    }
}
