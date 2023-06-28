using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage1 : MonoBehaviour
{
    public Enemy1 en;
    Bullet ak;
    BulletDrob drob;
    BulletKnife knife;
    // Start is called before the first frame update
    void Start()
    {
        ak = new Bullet();
        drob = new BulletDrob();
        knife = new BulletKnife();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Ak")
        //{
        //    en.curhlt -= ak.dmg;
        //}
        //if (collision.tag == "Drob")
        //{
        //    en.curhlt -= drob.dmg;
        //}
        //if (collision.tag == "Knife")
        //{
        //    en.curhlt -= knife.dmg;
        //}
        switch (collision.tag)
        {
            case "Ak":
                en.curhlt -= ak.dmg;
                break;
            case "Drob":
                en.curhlt -= drob.dmg;
                break;
            case "Knife":
                en.curhlt -= knife.dmg;
                break;
            default: break;
        }

    }
}
