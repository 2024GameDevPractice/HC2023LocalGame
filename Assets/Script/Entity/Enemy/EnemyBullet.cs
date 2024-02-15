using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    

    void Update()
    {
        rigid.velocity = -transform.right * bulletSpeed;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (!pc.isHit && !GameManager.Instance.isGod)
            {
                pc.hp -= damage;
                pc.Hitt();
                Destroy(gameObject);
            }
        }
    }
}
