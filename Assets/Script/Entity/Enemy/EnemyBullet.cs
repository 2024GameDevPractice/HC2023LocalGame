using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Destroy(transform.parent.gameObject, 5f);
    }

    void Update()
    {
        rigid.velocity = -transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (!pc.isHit)
            {
                pc.hp -= damage;
                pc.Hitt();
                Destroy(gameObject);
            }
        }
    }
}
