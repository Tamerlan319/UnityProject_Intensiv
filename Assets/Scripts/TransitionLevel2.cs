using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public bool[] tutorialTasks = new bool[4];
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //переход игрока на следующий уровень
        if (col.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
