using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : Enemy
{
    protected int maxHP;
    protected override void Init()
    {
        speed = 5;
    }

    protected override void Move()
    {
        rigid.velocity = Vector3.down * speed;
        if (transform.position.y <= 3.5f)
        {
            speed = 0;
            transform.position = new Vector3(transform.position.x, 3.501f);
            BossThink();
        }
        
    }

    protected abstract void BossThink();

    protected override void Shoot()
    {
    }
}
