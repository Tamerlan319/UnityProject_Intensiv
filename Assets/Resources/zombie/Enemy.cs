using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] point = new GameObject[14];
    private int action, rand = 0;
    public float speed = 1f;
    private Vector3 eulerAngles;
    private object quaternion;

    void Update()
    {
        if (action == 0)
        {
            if (point[rand].transform.parent != null)
            {
                for (int i = 0; i < point.Length; i++)
                {
                    point[i].transform.parent = null;
                }
            }

            if (transform.position != point[rand].transform.position)
            {
                Vector3 direction = point[rand].transform.position - transform.position;
                transform.position = Vector3.MoveTowards(transform.position, point[rand].transform.position, speed * Time.deltaTime);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                eulerAngles = transform.eulerAngles;
                eulerAngles.z = angle;
                transform.eulerAngles = eulerAngles;
            }
            else
            {
                rand = Random.Range(0, 13);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rand = Random.Range(0, 13);
    }
}
