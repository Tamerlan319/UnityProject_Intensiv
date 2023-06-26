using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Enemy en;
    Bullet ak;
    // Start is called before the first frame update
    void Start()
    {
        ak = new Bullet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ak")
        {
            en.curhlt -= ak.dmg;
        }
    }
}
