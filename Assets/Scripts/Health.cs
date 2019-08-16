using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int total_health;
    private float timeBtwDamage = 1.5f;
    public GameObject deathEffect;
    [HideInInspector] public int health;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        // set the max value for health bar to be same as the total health for boss
        healthBar.maxValue = total_health;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }
        healthBar.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        healthBar.value = health;
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
