using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Canvas canvas1, canvas2;
    public void Exist()
    {
        canvas1.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);
    }

}
