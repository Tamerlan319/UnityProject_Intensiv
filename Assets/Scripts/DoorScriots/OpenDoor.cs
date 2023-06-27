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
        vect = cols[0].transform.position;
        inCollider();
        doorstate[currentCollider].stateDoor();
        
    }
        
    
    public void inCollider()
    {
        for (int i = 0; i < cols.Length; i++) {
            if (cols[i].isActiveTrigger == true)
            {
                currentCollider = i;
            }
        }
    }
    //}
    //public void OnClick()
    //{
    //    doorstate.stateDoor();
    //}
}
