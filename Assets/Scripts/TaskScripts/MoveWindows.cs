using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWindows : MonoBehaviour
{
    public Canvas canvasPlay, canvasMain;
    public Canvas[] canvas; //задачи
    public int i;
    void Start()
    {
        //canvasMain = GetComponent<Canvas>();
        i = 0;
    }

    public void ShowTaskCanvas()
    {
        canvas[i].gameObject.SetActive(true);
        canvasMain.gameObject.SetActive(false);
    }
    public void HideDialogCanvas()
    {
        canvasMain.gameObject.SetActive(false);
        canvasPlay.gameObject.SetActive(true);
    }
}
