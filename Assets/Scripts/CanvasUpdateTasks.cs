using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUpdateTasks : MonoBehaviour
{
    GameObject[] doors;
    DoorState[] door;
    int countOfTasks;
    Text text;

    // Инициализация переменных
    void Start()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
        text = GetComponent<Text>();
        door = new DoorState[doors.Length];
        int i = 0;
        foreach (GameObject door1 in doors)
        {
            door[i] = door1.GetComponent<DoorState>();
            i++;
        }
    }

    // Обновление значения счётчика
    void Update()
    {
        countOfTasks = door.Length;
        foreach (var i in door)
        {
            if (!i.isLocked)
            {
                countOfTasks -= 1;
            }
        }
        text.text = countOfTasks.ToString();
    }
}
