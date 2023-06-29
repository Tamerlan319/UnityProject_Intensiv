using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.TextCore.Text;

public class Enemy_Test : MonoBehaviour
{
    public GameObject[] point = new GameObject[14];
    private static int action, rand = 0;
    public float speed = 1f;
    private Vector3 eulerAngles;
    public float angryDist = 7;
    public Transform player;
    public Animator anim;
    public static int health = 100;
    public int damage = 40;
    public Transform attackPoint;
    public float attackRange = 1.5f;
    public LayerMask enemyLayers;
    public float timeBtwAttack = 0;
    public float startTimeBtwAttack = 1;
    public int curhlt = 100;
    public SpriteRenderer spr;
    public Transform zombie;
    public GameObject tr;

    public void Regist()
    {
        if (curhlt <= 0)
        {
            Instantiate(spr, tr.transform.position, tr.transform.rotation);
            Destroy(tr);

        }
        if (action == 0)
        {
            anim.SetBool("Move", true);
            anim.SetBool("Attack", false);
            if (Vector3.Distance(tr.transform.position, player.transform.position) < angryDist)
            {
                tr.transform.position = Vector3.MoveTowards(tr.transform.position, player.transform.position, speed * Time.deltaTime);
                Vector3 direction = player.transform.position - tr.transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                eulerAngles = tr.transform.eulerAngles;
                eulerAngles.z = angle;
                tr.transform.eulerAngles = eulerAngles;
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
                if (tr.transform.position != point[rand].transform.position)
                {
                    Vector3 direction = point[rand].transform.position - tr.transform.position;
                    tr.transform.position = Vector3.MoveTowards(tr.transform.position, point[rand].transform.position, speed * Time.deltaTime);

                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    eulerAngles = tr.transform.eulerAngles;
                    eulerAngles.z = angle;
                    tr.transform.eulerAngles = eulerAngles;
                    angryDist = 7;
                    speed = 1f;
                }
                else
                {
                    rand = Random.Range(0, 13);
                }
            }
            if (Vector3.Distance(tr.transform.position, player.transform.position) < 2f)
            {
                action = 1;
            }
        }
        if (action == 1)
        {
            Vector3 direction = player.transform.position - tr.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            eulerAngles = tr.transform.eulerAngles;
            eulerAngles.z = angle;
            tr.transform.eulerAngles = eulerAngles;
            anim.SetBool("Move", false);
            anim.SetBool("Attack", true);
            Attack();
            if (Vector3.Distance(tr.transform.position, player.transform.position) > 2f)
            {
                action = 0;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rand = Random.Range(0, 13);
    }

    public void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            player.GetComponent<Player>().TakeDamage(damage);
            speed = 0;
            timeBtwAttack = startTimeBtwAttack;
        }
        else timeBtwAttack -= Time.deltaTime;
    }
}