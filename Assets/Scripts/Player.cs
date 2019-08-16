using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int totalHealth;
    public GameObject deathEffect;
    public Slider healthBar;
    public AudioSource hurtSound;

    private float timeBtwDamage = 1.5f;

    [HideInInspector] public int state = 1; // state = 0, idle state
    [HideInInspector] public int skill = 0; // skill = 0, not doing anything
    [HideInInspector] public int health;

    private void Start()
    {
        health = totalHealth;
        healthBar.maxValue = totalHealth;
        healthBar.value = health;
        state = 1;
        Debug.Log("PLAYER STATE: " + state);
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
        if (!hurtSound.isPlaying)
        {
            hurtSound.Play();
        }
        health -= damage;
        Debug.Log("Current Health: " + health);
        //Pseudo Berserk Blood Mode
        /*if (health <= 900 && health > 500 && state != 1)
        {
            Debug.Log("Player Change State");
            state = 1;
            Debug.Log("Player State: " + state);
        }*/
        //Pseudo Quit Berserk Blood Mode
        /*if (health <= 500 && state != 0)
        {
            state = 0;
        }*/
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Dead");
        //state = 0;
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public void ResetPlayer(Transform spawnPoint)
    {
        health = totalHealth;
        healthBar.value = health;
        Debug.Log("FINAL CURRENT HEALTH: " + health);
        transform.position = spawnPoint.transform.position;
        // transform.rotation = spawnPoint.transform.rotation;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();
        Boss boss = collider.GetComponent<Boss>();
        if (enemy != null)
        {
            Debug.Log("Touch enemy!");
            enemy.TakeDamage(2000);
        }

        if (boss != null)
        {
            enemy.TakeDamage(2000);
        }


    }
}
