using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy

{
    protected override void Init()
    {
        speed = 10;
        hp = 40;
        damage = 2;
    }
    private new void Update()
    {
        base.Update();
        if (hp <= 0)
        {
            anim.SetTrigger("Explode");
            Destroy(gameObject, 0.3f);
        }
    }
    protected override void Move()
    {
        rigid.velocity = -transform.up * speed;
    }
    protected override void Shoot()
    {

    }
}
