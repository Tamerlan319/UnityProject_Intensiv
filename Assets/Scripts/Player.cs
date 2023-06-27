using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

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


    public AnimationClip atKnife, atAk, atDrob, idle;

    public Sprite ak, drob, knife;
    public SpriteRenderer spriteRenderer;

    private int sostoyanie = 2;

    public Transform player;


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
        
        //spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("Attack", false);
        //anim.SetBool("idleKnife", true);
        Vector3 moveVector = (Vector3.up * joystick.Horizontal + Vector3.left * joystick.Vertical);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }
        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput.normalized * speed;
        switch (sostoyanie)
        {
            case 0:
                spriteRenderer.sprite = knife;
                //anim.SetBool("AttackKnife", false);
                //anim.SetBool("AttackAk", false);
                //anim.SetBool("AttackDrob", false);
                //anim.SetBool("IdleKnife", true);

                gun1.gameObject.SetActive(false);
                break;
            case 1:

                //anim.SetBool("AttackKnife", false);
                //anim.SetBool("AttackAk", true);
                //anim.SetBool("AttackDrob", false);
                //anim.SetBool("IdleKnife", false);

                gun1.gameObject.SetActive(true);
                spriteRenderer.sprite = ak;
                break;
            case 2:
                anim.SetBool("AttackKnife", false);
                anim.SetBool("AttackAk", false);
                anim.SetBool("AttackDrob", true);
                anim.SetBool("IdleKnife", false);

                
                gun1.gameObject.SetActive(false);
                spriteRenderer.sprite = drob;

                break;
            default: break;
        }

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
