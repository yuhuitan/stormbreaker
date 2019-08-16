using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public float speed = 3f;
    //public Rigidbody2D rb;
    private int damage = 20;


    void Start()
    {
        //rb.velocity = transform.right * speed;
       // GameManager.enemyAlive++;
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log(player);
            player.TakeDamage(damage);
            Debug.Log("player current health" + player.health);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log(player);
            player.TakeDamage(damage);
            Debug.Log("player current health" + player.health);
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        //GameManager.enemyAlive--;
        Destroy(gameObject);

    }

}
