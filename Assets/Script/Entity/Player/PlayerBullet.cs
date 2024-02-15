using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{

    void Update()
    {
        rigid.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerStay2D(Collider2D other)
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
