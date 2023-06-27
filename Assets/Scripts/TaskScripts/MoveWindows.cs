using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWindows : MonoBehaviour
{
    public Canvas canvasPlay, canvasMain;
    public Canvas[] canvas; //задачи
    int i;
    void Start()
    {
        //canvasMain = GetComponent<Canvas>();
        i = 0;
    }

    public void ShowTaskCanvas()
    {
        canvas[i].gameObject.SetActive(true);
        canvasMain.gameObject.SetActive(false);
        i++;
    }
    public void HideDialogCanvas()
    {
        canvasMain.gameObject.SetActive(false);
        canvasPlay.gameObject.SetActive(true);
    }
}
