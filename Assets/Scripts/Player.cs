using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Player : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    public static int health = 100;
    public int curhlt;
    public Animator anim;
    public Gun gun1;
    public GunDrob gun2;
    public AttackKnife knifeGun;
    private float timeBtwShots = 1;
    public AudioSource aud;
    public AudioClip[] clips;
    AudioSource steps;
    bool isMove = false;
    public Sprite ak, drob, knife;
    public SpriteRenderer spriteRenderer;
    public float timeBtwSteps;
    float startTimeBtwSteps;

    private int sostoyanie = 2;

    public Transform player;
    public int action = 0;


    public void TakeDamage(int damage)
    {
        curhlt -= damage;
        if (curhlt <= 0)
        {
            if (curhlt == -20) curhlt += 20;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            curhlt = 100;
        }
        health = curhlt;
    }
    void Start()
    {
        //curhlt = health;
        health = curhlt;
        rb = GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
        steps = GetComponent<AudioSource>();
        
        //spriteRenderer = GetComponent<SpriteRenderer>();

    }


    // Update is called once per frame
    void Update()
    {
        timeBtwSteps -= Time.deltaTime;
        //anim.SetBool("Attack", false);
        //anim.SetBool("idleKnife", true);
        Vector3 moveVector = (Vector3.up * joystick.Horizontal + Vector3.left * joystick.Vertical);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            isMove = true;
        }
        else { isMove = false; }
        if (!isMove & timeBtwSteps <= 0)
        {
            steps.Play();
            timeBtwSteps = startTimeBtwSteps;
        }
        //else steps.Stop();
        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput.normalized * speed;
        switch (sostoyanie)
        {
            case 0:
                spriteRenderer.sprite = knife;
                

                //anim.SetBool("isKnife", true);

                if(knifeGun.timeBtwShots <= 0.2)
                {
                    aud.clip = clips[0];
                    anim.SetBool("isKnife", true);
                    anim.SetBool("isAk", false);
                    anim.SetBool("isDrob", false);
                }
                else
                {
                    anim.SetBool("isKnife", false);
                    anim.SetBool("isAk", false);
                    anim.SetBool("isDrob", false);
                }

                gun1.gameObject.SetActive(false);
                gun2.gameObject.SetActive(false);
                knifeGun.gameObject.SetActive(true);
                action = 0;
                break;
            case 1:
                aud.clip = clips[1];
                anim.SetBool("isKnife", false);
                anim.SetBool("isAk", true);
                anim.SetBool("isDrob", false);

                gun1.gameObject.SetActive(true);
                gun2.gameObject.SetActive(false);
                knifeGun.gameObject.SetActive(false);
                spriteRenderer.sprite = ak;
                action = 1;
                break;
            case 2:
                aud.clip = clips[2];
                anim.SetBool("isKnife", false);
                anim.SetBool("isAk", false);
                anim.SetBool("isDrob", true);

                
                gun1.gameObject.SetActive(false);
                gun2.gameObject.SetActive(true);
                knifeGun.gameObject.SetActive(false);
                spriteRenderer.sprite = drob;
                action = 2;

                break;
            default: break;
        }

    }
    public float time, sec = 1;
    public void An()
    {
        anim.SetBool("isKnife", true);
        if (time > sec)
        {
            Debug.Log("");
            time = 0;
        }
        time += Time.deltaTime;
        anim.SetBool("isKnife", false);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        
    }
    public void Gun1()
    {
        sostoyanie = 1;
    }
    public void Gun2()
    {
        sostoyanie = 2;
    }
    public void Knife()
    {
        sostoyanie = 0;
    }
}
