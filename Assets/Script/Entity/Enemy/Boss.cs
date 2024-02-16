using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : Enemy
{
    protected int maxHP;
    protected float stopY;
    protected Coroutine skillCorou;
    protected override void Init()
    {
        speed = 5;
    }

    protected new void Update()
    {
        base.Update();
        GameManager.uiManager.bossHPBar.fillAmount = (float)hp / maxHP;
    }

    protected override void Move()
    {
        rigid.velocity = Vector3.down * speed;
        if (transform.position.y <= stopY)
        {
            speed = 0;
            transform.position = new Vector3(transform.position.x, stopY+0.001f);
            BossThink();
        }
        
    }

    protected abstract void BossThink();

    private void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
        GameManager.uiManager.bossHPBar.fillAmount = (float)hp / maxHP;
    }
    protected override void Die()
    {
        if (hp <= 0)
        {
            GameManager.uiManager.bossHPBar.fillAmount = (float)hp / maxHP;
            StartCoroutine(DieMotion());
        }
    }

    IEnumerator DieMotion()
    {
        StopCoroutine(skillCorou);
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    protected override void Shoot()
    {
    }
}
