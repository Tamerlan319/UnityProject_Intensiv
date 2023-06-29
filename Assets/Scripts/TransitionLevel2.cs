using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    bool isLocked = true;
    public DoorState[] doors;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        CheckDone();
        //переход игрока на следующий уровень
        if (col.tag == "Player" & !isLocked)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void CheckDone()
    {
        foreach (var i in doors)
        {
            if (i.isLocked == false)
            {
                isLocked = false;
            }
            else
            {
                isLocked = true;
                break;
            }
        }
    }
}
