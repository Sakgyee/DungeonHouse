using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{ 

    public float moveSpeed = 2.0f; // Mob movement speed
    public float detectionRange = 5.0f; // Range at which the mob detects the player

    private Transform player; // Player's position
    private Rigidbody2D Rigidbody2D;

    public float hitCooldown = 3.0f; // Cooldown time before the mob can hit the player again
    private float lastHitTime = 0.0f; // Time of the last hit
    private bool canHitPlayer = true;

    private ScanPlayer scanPlayer;
    private CircleCollider2D circleCollider2D;


    public int enemyHealth;
    public int enemymaxHealth = 90;
    public int damage = 30;
    
    void Start()
    {
        enemyHealth = enemymaxHealth;

        Rigidbody2D = GetComponent<Rigidbody2D>();
        scanPlayer = transform.parent.GetComponent<ScanPlayer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {

    }


    // Handle collision with the player
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canHitPlayer && Time.time - lastHitTime > hitCooldown)
        {
                      
            lastHitTime = Time.time;

            // Disable further hits for a brief cooldown
            StartCoroutine(DisableHitCooldown());
        }

        if (collision.gameObject.CompareTag("Attack"))
        {
            scanPlayer.ReduceHealth(damage);         

            /*
            if (scanPlayer != null)
            {
                // Calculate the direction from the enemy to the ScanPlayer game object
                Vector2 pushDirection = (scanPlayer.transform.position - transform.position).normalized;

                // Apply a force to push the ScanPlayer game object back in the opposite direction
                scanPlayer.PushBack(pushDirection);
            }
            */

        }
    }
 

    IEnumerator DisableHitCooldown()
    {
        canHitPlayer = false;
        yield return new WaitForSeconds(hitCooldown);
        canHitPlayer = true;
    }

   

}


