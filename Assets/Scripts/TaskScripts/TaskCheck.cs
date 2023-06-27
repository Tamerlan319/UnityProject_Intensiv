using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskCheck : MonoBehaviour
{
    public InputField input;
    public string answer;
    public DoorState[] doorstate;
    public ColliderState[] cols;
    public Canvas canvas;
    public Canvas PlayerCanvas;
    public OpenDoor openDoor;
    int i = 0;
    void Start()
    {
    }

    public void CheckAnswer()
    {
        if (input.text == answer)
        {
            doorstate[openDoor.inCollider(cols)].isLocked = false;
            canvas.gameObject.SetActive(false);
            PlayerCanvas.gameObject.SetActive(true);
        }
        else
        {
            input.text = "";
            input.placeholder.GetComponent<Text>().text = "����� ��������!";
        }
    }
}
