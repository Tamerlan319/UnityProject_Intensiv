using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : MonoBehaviour
{
    public GameObject[] point = new GameObject[14];
    private int action, rand = 0;
    public float speed = 1f;
    private Vector3 eulerAngles;
    private object quaternion;
    public float angryDist = 20;
    private Transform player;
    
        

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (action == 0)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < angryDist)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                Vector3 direction = player.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                eulerAngles = transform.eulerAngles;
                eulerAngles.z = angle;
                transform.eulerAngles = eulerAngles;
                angryDist = 15;
                speed = 1f * 3;
            }
            else
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
                    angryDist = 7;
                    speed = 1f;
                }
                else
                {
                    rand = Random.Range(0, 13);

                }
            }
            //if (Vector3.Distance(transform.position, player.transform.position) < angryDist)
            //{
            //    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);   // Дальность Агра
            //}


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rand = Random.Range(0, 13);
        //if (Vector3.Distance(transform.position, player.transform.position) < angryDist)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);   // Дальность Агра
        //}
    }
    private void OnDrawGizmosSelected() // Показывает область 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, angryDist);

    }
}