using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Destroy(transform.parent.gameObject, 5f);
    }

    void Update()
    {
        rigid.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (!enemy.isHit)
            {
                enemy.hp -= damage;
                enemy.Hitt();
                Destroy(gameObject);
            }
        }
    }
}
