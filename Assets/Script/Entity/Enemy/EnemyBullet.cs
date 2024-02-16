
using Unity.Mathematics;
using UnityEngine;

public class EnemyBullet : Bullet
{
    public bool isDirectBullet;
    int stack;
    float timer;
    void Update()
    {
        if (isDirectBullet)
        {
            timer += Time.deltaTime;
            Vector2 dis = GameManager.Instance.player.position - transform.position;
            float rotZ = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
            quaternion angle = Quaternion.Euler(0f, 0f, rotZ + 180);
            if (timer > 0.1f && stack < 12)
            {
                timer = 0;
                stack++;
                transform.rotation = angle;
            }
        }
        rigid.velocity = -transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
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
