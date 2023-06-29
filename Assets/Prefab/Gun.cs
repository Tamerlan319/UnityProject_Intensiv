using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public AudioSource aud;
    // Start is called before the first frame update
    public Player pl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        if (pl.action == 1)
        {
            //Vector3 df = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //float rotZ = Mathf.Atan2(df.y, df.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            if (timeBtwShots <= 0)
            {
                //if (Input.GetMouseButton(0))
                //{
                aud.Play();
                Instantiate(bullet, shotPoint.position, transform.rotation);
                //timeBtwShots = startTimeBtwShots;
                //}
            }
            //else timeBtwShots -= Time.deltaTime;
        }
    }
}
