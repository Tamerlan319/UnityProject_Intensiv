using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorState : MonoBehaviour
{
    bool doorOpen = false;
    public Animator anim;
    public bool isActiveTrig;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void stateDoor()
    {
        if (!doorOpen)
        {
            doorOpen = true;
            anim.SetBool("isOpen", true);
            anim.SetBool("isClosed", false);
        }
        else {
            doorOpen = false;
            anim.SetBool("isOpen", false);
            anim.SetBool("isClosed", true);
        }
    }
}
