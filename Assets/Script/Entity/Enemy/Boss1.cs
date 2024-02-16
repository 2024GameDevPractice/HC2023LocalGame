using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Boss1 : Boss
{
    protected override void Init()
    {
        base.Init();
        hp = 2000;
        maxHP = hp;
        stopY = 3.5f;
    }

    protected override void BossThink()
    {
        int paternIndex = UnityEngine.Random.Range(0, 2);

        switch (paternIndex)
        {
            case 0:
                ShootAround();
                break;
            case 1:
                ShootDirect();
                break;
        }
    }

    private void ShootAround()
    {
        skillCorou = StartCoroutine(AroundShot());
    }

    IEnumerator AroundShot()
    {
        for (int i = 0; i < 18; i++)
        {
            GameObject tempOb = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, i * 20));
            if (tempOb != null)
                tempOb.GetComponentInChildren<EnemyBullet>().bulletSpeed = 5;
        }
        yield return new WaitForSeconds(0.75f);
        for (int i = 0; i < 18; i++)
        {
            GameObject tempOb = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, i * 20 + 10));
            if (tempOb != null)
                tempOb.GetComponentInChildren<EnemyBullet>().bulletSpeed = 5;
        }
        yield return new WaitForSeconds(0.75f);
        for (int i = 0; i < 18; i++)
        {
            GameObject tempOb = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, i * 20));
            if (tempOb != null)
                tempOb.GetComponentInChildren<EnemyBullet>().bulletSpeed = 5;
        }
        Invoke("BossThink", 2.5f);
    }

    void ShootDirect()
    {
        skillCorou = StartCoroutine(DirectShoot());
    }

    private IEnumerator DirectShoot()
    {
        for (int i = 0; i < 30; i++)
        {
            Vector2 dis = GameManager.Instance.player.position - transform.position;
            float rotZ = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
            quaternion angle = Quaternion.Euler(0f, 0f, rotZ + 180);
            GameObject tempOb1 = Instantiate(bullet, transform.position + new Vector3(-0.8f, -3.3f), angle);
            GameObject tempOb2 = Instantiate(bullet, transform.position + new Vector3(0.8f, -3.3f), angle);

            tempOb1.GetComponentInChildren<EnemyBullet>().bulletSpeed = 10;
            tempOb2.GetComponentInChildren<EnemyBullet>().bulletSpeed = 10;

            yield return new WaitForSeconds(0.1f);
        }

        Invoke("BossThink", 2.5f);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
        GameManager.uiManager.bossHPBar.fillAmount = (float)hp / maxHP;
    }
}
