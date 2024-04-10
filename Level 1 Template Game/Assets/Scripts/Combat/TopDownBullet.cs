using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownBullet : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject enemy;
    public float bulletSpeed, bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletSpeed);
        enemy = GameObject.FindWithTag("Target");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Target"))
        {
            other.GetComponent<BasicEnemy>().TakeDamage(bulletDamage);
        }
    }
}
