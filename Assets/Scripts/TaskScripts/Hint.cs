using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    bool isShowHint = false;
    RawImage rw;
    public Texture2D hint, task;
    private void Start()
    {
        rw = gameObject.GetComponent<RawImage>();
    }
    public void ShowHint()
    {
        if (!isShowHint)
        {
            rw.texture = hint;
            isShowHint = true;
        }
        else
        {
            rw.texture = task;
            isShowHint = false;
        }
    }
}
