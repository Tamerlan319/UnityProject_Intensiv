using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osnova3 : MonoBehaviour
{
    public GameObject[] point = new GameObject[14];
    public float speed = 1f;
    public float angryDist = 7;
    private Transform player;
    private Animator anim;
    public int damage = 40;
    private Transform attackPoint;
    public float attackRange = 1.5f;
    public int curhlt = 100;
    private SpriteRenderer spr;

    private Transform zombie;
    private Enemy_Test enemy_test;
    private GameObject tr;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        string resourcePath = "zombie/Zombie/zombi";
        spr = Resources.Load<SpriteRenderer>(resourcePath);
        if (spr != null)
        {
            GetComponent<SpriteRenderer>().sprite = spr.sprite;
        }
        else
        {
            Debug.LogError("Failed to load SpriteRenderer at path: " + resourcePath);
        }
        anim = GetComponent<Animator>();
        tr = gameObject;
        enemy_test = new Enemy_Test();
        zombie = transform;
        attackPoint = transform;
        enemy_test.point = point;
        enemy_test.speed = speed;
        enemy_test.angryDist = angryDist;
        enemy_test.anim = anim;
        enemy_test.damage = damage;
        enemy_test.attackPoint = attackPoint;
        enemy_test.curhlt = curhlt;
        enemy_test.spr = spr;
        enemy_test.zombie = zombie;
        enemy_test.player = player;
        enemy_test.tr = tr;
    }

    void Update()
    {
        enemy_test.curhlt = curhlt;
        enemy_test.Regist();
    }
}
