using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int total_health;
    public GameObject deathEffect;
    public Slider healthBar;
    public int bossId;

    private float timeBtwDamage = 1.5f;
    private int recoverState = 2;
    private int frenzyState = 4;
    private int finalBossId = 3;


    [HideInInspector] public int health;
    [HideInInspector] public bool hit;
    [HideInInspector] public int hitBySkillIndex;
    [HideInInspector] public int currentState;
    [HideInInspector] public bool boxTrigger;

    // Start is called before the first frame update
    void Start()
    {
        // set the max value for health bar to be same as the total health for boss
        health = total_health;
        healthBar.maxValue = total_health;
        healthBar.value = health;
        //GameManager.enemyAlive += 1;
        Debug.Log("Testing: "+GameManager.enemyAlive);
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
        // If  boss 3 in frenzy or recover state, full guard mode, cannot be attack
        if (!(currentState == recoverState && bossId == finalBossId && boxTrigger) && !(currentState == frenzyState && bossId == finalBossId && boxTrigger))
        {
            health -= damage;
            if (health <= 0)
            {
                Debug.Log("Testing 2:" +GameManager.enemyAlive);
                GameManager.enemyAlive -= 1;
                Die();
            }
            healthBar.value = health;
        }
 
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

}
