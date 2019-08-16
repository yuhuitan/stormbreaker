using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public bool range_damage = false;
    public int damage = 10;
    public int min_damage = 0;
    public int max_damage = 10;
    public GameObject impactEffect;
    public bool moving = true;

    private int decided_damage;

    // Start is called before the first frame update
    void Start()
    {
        if (moving)
        {
            rb.velocity = transform.right * speed;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (range_damage)
        {
            decided_damage = Random.Range(min_damage, max_damage);
        }
        else
        {
            decided_damage = damage;
        }

        // check if the collider collides with any objects
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(decided_damage);
          //  Debug.Log("Hit Player: " + decided_damage);
            Destroy(gameObject);
        }
       // Instantiate(impactEffect, transform.position, transform.rotation);
        // destroy the gameObject upon hitting something
        // destroy the gameObject once it is out of the scene


    }
}
