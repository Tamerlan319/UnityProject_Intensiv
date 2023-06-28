using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.TextCore.Text;

public class Enemy4 : MonoBehaviour
{
    public GameObject[] point = new GameObject[14];
    private static int action, rand = 0;
    public float speed = 1f;
    private Vector3 eulerAngles;
    private object quaternion;
    public float angryDist = 7;
    private Transform player;
    public Animator anim;
    public static int health = 100;
    public int damage = 40;
    public Transform attackPoint;
    public float attackRange = 1.5f;
    public LayerMask enemyLayers;
    public float timeBtwAttack;
    public float startTimeBtwAttack = 1;
    public string PointAt;
    public int curhlt = 100;
    public SpriteRenderer spr;
    public Transform zombie;


    public void TakeDamage(int damage)
    {
        curhlt -= damage;
        if (curhlt < 0)
        {
            //speed = 0;
            speed = 0f;
        }
        health = curhlt;
    }

    public void Attack()
    {
        {

        }
        if (timeBtwAttack <= 0)
        {
            Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            //Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            //foreach (Collider2D player in hitPlayers)
            //{
            player.GetComponent<Player>().TakeDamage(damage);
            //}
            speed = 0;
            timeBtwAttack = startTimeBtwAttack;
        }
        else timeBtwAttack -= Time.deltaTime;
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void Start()
    {
        curhlt = health;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //attackPoint = GameObject.FindGameObjectWithTag(PointAt).transform;
        anim = GetComponent<Animator>();

    }
    void Update()
    {
        if (curhlt <= 0)
        {
            //speed = 0;
            GameObject g = gameObject;
            Instantiate(spr, g.transform.position, g.transform.rotation);
            Destroy(g);

        }
        if (action == 0)
        {
            anim.SetBool("Move", true);
            anim.SetBool("Attack", false);
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
            if (Vector3.Distance(transform.position, player.transform.position) < 2f)
            {
                action = 1;
            }

            //if (Vector3.Distance(transform.position, player.transform.position) < angryDist)
            //{
            //    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);   // Дальность Агра
            //}


        }
        if (action == 1)
        {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            eulerAngles = transform.eulerAngles;
            eulerAngles.z = angle;
            transform.eulerAngles = eulerAngles;
            anim.SetBool("Move", false);
            anim.SetBool("Attack", true);


            Attack();

            if (Vector3.Distance(transform.position, player.transform.position) > 2f)
            {
                action = 0;
            }
        }
        if (health == 0)
        {

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
}