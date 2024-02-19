using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : Enemy
{
    protected int maxHP;
    protected float stopY;
    protected Coroutine skillCorou1;
    protected Coroutine skillCorou2;
    protected override void Init()
    {
        speed = 5;
    }

    new private void OnEnable()
    {
        base.OnEnable();
        GameManager.Instance.isBoss = true;

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
            transform.position = new Vector3(transform.position.x, stopY + 0.001f);
            BossThink();
        }

    }

    protected abstract void BossThink();

    public void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
        GameManager.Instance.isBossDead = true;
        GameManager.Instance.ScoreBoard.SetActive(true);
        GameManager.uiManager.bossHP.SetActive(false);
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
        speed = 0;
        if (skillCorou1 != null)
            StopCoroutine(skillCorou1);
        if (skillCorou2 != null)
            StopCoroutine(skillCorou2);
        anim.SetTrigger("Die");
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    protected override void Shoot()
    {
    }
}
