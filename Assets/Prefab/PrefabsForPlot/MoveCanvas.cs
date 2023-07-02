using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanvas : MonoBehaviour
{
    public Canvas canvasPlayer;
    public Canvas message;
    void Start()
    {
        //message = GetComponent<Canvas>();
    }

    public void closeCanvas()
    {
        canvasPlayer.gameObject.SetActive(true);
        message.gameObject.SetActive(false);
    }
    public void openCanvas()
    {
        canvasPlayer.gameObject.SetActive(false);
        message.gameObject.SetActive(true);
    }
}
