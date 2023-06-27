using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackKnife : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    public float timeBtwShots;
    public float startTimeBtwShots;
    private Enemy en;
    public bool flag = false;
    public Animator anim;
    public Player pl;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        timeBtwShots -= Time.deltaTime;
    }
    public void Attack()
    {
        if (pl.action == 0)
        {


            if (timeBtwShots <= -0.2)
            {
                //if (Input.GetMouseButton(0))
                //{
                
                //anim.SetBool("isKnife", true);
                if (flag)
                {
                    Instantiate(bullet, shotPoint.position, transform.rotation);
                    
                }
                timeBtwShots = startTimeBtwShots;
                //}
            }
            //else ;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && collision != null)
        {
            flag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && collision != null)
        {
            flag = false;
        }
    }
}
