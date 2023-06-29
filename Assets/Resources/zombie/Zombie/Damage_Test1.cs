using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Test1 : MonoBehaviour
{
    public Osnova1 en;
    Bullet ak;
    BulletDrob drob;
    BulletKnife knife;

    void Start()
    {
        ak = new Bullet();
        drob = new BulletDrob();
        knife = new BulletKnife();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
