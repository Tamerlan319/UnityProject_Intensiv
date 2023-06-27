using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDrob : MonoBehaviour
{
    public float offset;
    public GameObject bullet1, bullet2, bullet3;
    public Transform shotPoint1, shotPoint2, shotPoint3;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public Player pl;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 vex1 = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 df = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(df.y, df.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(shotPoint1.transform.rotation.x, shotPoint1.transform.rotation.y, shotPoint1.transform.rotation.z + 90f);
        
    }
    public void Attack()
    {
        if (pl.action == 2)
        {
            if (timeBtwShots <= 0)
            {
                //if (Input.GetMouseButton(0))
                //{
                Instantiate(bullet1, shotPoint1.position, transform.rotation);
                Instantiate(bullet2, shotPoint2.position, transform.rotation);
                Instantiate(bullet3, shotPoint3.position, transform.rotation);
                //timeBtwShots = startTimeBtwShots;
                //}
            }
        }
    }
}
