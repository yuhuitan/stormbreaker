using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject impactEffect;
    public int skillIndex;
    public AudioSource effect;

    // Start is called before the first frame update
    void Start()
    {
        effect.Play();
        rb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Boss boss = collider.GetComponent<Boss>();
        Enemy enemy = collider.GetComponent<Enemy>();
        if (boss != null)
        {
            if (collider.GetType() == typeof(BoxCollider2D))
            {
                boss.boxTrigger = true;
            }
            boss.hit = true;
            boss.hitBySkillIndex = skillIndex;
            boss.TakeDamage(damage);
            boss.boxTrigger = false;
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
