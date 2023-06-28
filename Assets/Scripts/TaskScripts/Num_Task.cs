using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Num_Task : MonoBehaviour
{
    RawImage rw;
    public Texture2D task;
    private void Start()
    {
        rw = gameObject.GetComponent<RawImage>();
    }
    public void ShowTask()
    {
        rw.texture = task;
    }
}
