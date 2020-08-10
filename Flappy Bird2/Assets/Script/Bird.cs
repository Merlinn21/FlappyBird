using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    //physics
    public float upForce = 100f;
    [HideInInspector]public bool isDead = false;
    private Rigidbody2D rb;

    //audio
    public UnityEvent onJump;
    public UnityEvent onDead;
    public UnityEvent onHit;
    public UnityEvent onShoot;
    public UnityEvent onPoin;

    //animator
    private Animator anim;

    //shoot
    public GameObject ShootLocation;
    public GameObject bulletPrefab;
    public float shootInterval = 10f;
    public bool shootCD = false;

    public GameManager gm;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        Jump();
        Shoot();
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, upForce));

            onJump.Invoke();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isDead)
            Hit();
    }

    public void Hit()
    {
        onHit.Invoke();
        Dead();
    }
    
    public void Dead()
    {
        isDead = true;
        anim.enabled = false;
        gm.GameOver();
        onDead.Invoke();
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !shootCD)
        {
            Instantiate(bulletPrefab, ShootLocation.transform);
            onShoot.Invoke();
            StartCoroutine("ShootCoolDown");
        }
    }

    IEnumerator ShootCoolDown()
    {
        shootCD = true;
        yield return new WaitForSeconds(shootInterval);
        shootCD = false;
        Shoot();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Poin")
        {
            if (!isDead)
            {
                gm.poin++;
                gm.UpdateScore();
                onPoin.Invoke();
            }          
        }
    }
}
