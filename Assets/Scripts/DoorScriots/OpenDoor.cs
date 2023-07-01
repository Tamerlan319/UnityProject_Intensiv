using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public Button button;
    public Player player;
    public DoorState[] doorstate;
    public ColliderState[] cols;
    GameObject door;
    public int currentCollider = 0;
    public Vector2 vect = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }
    public void buttonHide()
    {
        button.gameObject.SetActive(false);
    }
    public void buttonShow()
    {
        button.gameObject.SetActive(true);
    }
    public void OnClick()
    {
        doorstate[inCollider(cols)].stateDoor();
        
    }
        
    
    public int inCollider(ColliderState[] cols)
    {
        if (cols[currentCollider].isActiveTrigger == true)
        {
            return currentCollider;
        }
        else
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].isActiveTrigger == true)
                {
                    currentCollider = i;
                }
            }
            return currentCollider;
        }
    }
    //}
    //public void OnClick()
    //{
    //    doorstate.stateDoor();
    //}
}
