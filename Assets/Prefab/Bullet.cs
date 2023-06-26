using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage = 10;
    public int dmg;
    public LayerMask whatIsSolid;
    // Start is called before the first frame update
    void Start()
    {
        damage = 10;
    }

    public Bullet ()
    {
        dmg = damage;
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        //hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);

        if (hitInfo.collider != null)
        {
            double sec = 0.2;
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                //hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                sec -= Time.deltaTime;
                Destroy(gameObject);
            }

        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
