using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] point = new GameObject[14];
    private int action, rand = 0;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                transform.position = Vector3.MoveTowards(transform.position, point[rand].transform.position, speed = Time.deltaTime);
                var direction = point[rand].transform.forward - transform.position;
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
                rand = Random.Range(0, 13);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rand = Random.Range(0, 13);
    }
}
