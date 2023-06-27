using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHideTrigger : MonoBehaviour
{
    public Button button;
    private void Start()
    {
        //button = GetComponent<Button>();
        button.gameObject.SetActive(false);
    }
    OpenDoor open;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") button.gameObject.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")  button.gameObject.SetActive(false);
    }
}
