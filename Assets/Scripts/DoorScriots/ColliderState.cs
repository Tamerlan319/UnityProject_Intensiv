using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderState : MonoBehaviour
{
    public bool isActiveTrigger = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        isActiveTrigger = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        isActiveTrigger = false;
    }
}
