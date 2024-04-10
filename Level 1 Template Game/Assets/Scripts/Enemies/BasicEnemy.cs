using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    GameObject playerObject;
    public float enemySpeed, enemyHealth, attackRate, attackDelay, damageAmount, attackDistance;
    public int scoreAmount;
    Rigidbody2D rb2D;
    
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        EnemyMove();
    }
    void Update()
    {
        if(Time.time > attackDelay)
        {
            if(Vector2.Distance(playerObject.transform.position, transform.position) <=  attackDistance)
            {
                playerObject.GetComponent<PlayerHealth>().playerHealth -= damageAmount;
                attackDelay = Time.time + attackRate;
            }
        }
    }

    void EnemyMove()
    {
        float step = enemySpeed * Time.deltaTime;
        rb2D.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, step);
    }

    public void TakeDamage(float amount)
    {
        enemyHealth -= amount;
        if(enemyHealth <= 0)
        {
            playerObject.GetComponent<TopDownMovement>().scoreNum += scoreAmount;
            Destroy(gameObject);
        }
    }
}
