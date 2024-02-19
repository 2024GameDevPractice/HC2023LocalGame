using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss2 : Boss
{
    protected override void Init()
    {
        base.Init();
        hp = 5000;
        maxHP = hp;
        stopY = 3f;
    }

    protected override void BossThink()
    {
        int paternIndex = UnityEngine.Random.Range(0, 3);

        switch (paternIndex)
        {
            case 0:
                ShootVane();
                break;
            case 1:
                ShootDirect();
                break;
            case 2:
                ShootAround();
                break;
        }
    }

    private void ShootVane()
    {
        skillCorou1 = StartCoroutine(VaneShot1());
        skillCorou2 = StartCoroutine(VaneShot2());
    }

    IEnumerator VaneShot1()
    {
        int stack = 0;
        for (int i = 0; i < 60; i++)
        {

            if (stack < 3)
            {
                GameObject tempOb = Instantiate(bullet, transform.position + (Vector3.left * 0.8f), Quaternion.Euler(0f, 0f, -(i * 8) + 145));
                if (tempOb != null)
                    tempOb.GetComponentInChildren<EnemyBullet>().bulletSpeed = 5;
                stack++;
            }
            else if (stack == 3)
                stack = 0;
            yield return new WaitForSeconds(0.05f);
        }
        Invoke("BossThink", 2.5f);
    }
    IEnumerator VaneShot2()
    {
        int stack = 0;
        for (int i = 0; i < 60; i++)
        {
            Debug.Log(stack);
            if (stack < 3)
            {
                GameObject tempOb = Instantiate(bullet, transform.position + (Vector3.right * 0.8f), Quaternion.Euler(0f, 0f, (i * 8) + 35));
                if (tempOb != null)
                    tempOb.GetComponentInChildren<EnemyBullet>().bulletSpeed = 5;
                stack++;
            }
            else if (stack == 3)
                stack = 0;

            yield return new WaitForSeconds(0.05f);
        }
    }

    void ShootDirect()
    {
        skillCorou1 = StartCoroutine(DirectShoot());
    }

    private IEnumerator DirectShoot()
    {
        for (int i = 0; i < 8; i++)
        {
            Vector2 dis = GameManager.Instance.player.position - transform.position;
            float rotZ = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
            quaternion angle = Quaternion.Euler(0f, 0f, rotZ + 180);
            GameObject tempOb1 = Instantiate(bullet, transform.position + (Vector3)new Vector2(Random.Range(-1f, 2), Random.Range(-1f, 2)), angle);
            GameObject tempOb2 = Instantiate(bullet, transform.position + (Vector3)new Vector2(Random.Range(-1, 2f), Random.Range(-1, 2f)), angle);

            tempOb1.GetComponentInChildren<EnemyBullet>().bulletSpeed = 8;
            tempOb2.GetComponentInChildren<EnemyBullet>().bulletSpeed = 8;
            tempOb1.GetComponentInChildren<EnemyBullet>().isDirectBullet = true;
            tempOb2.GetComponentInChildren<EnemyBullet>().isDirectBullet = true;

            yield return null;
        }

        Invoke("BossThink", 2.5f);
    }

    void ShootAround()
    {
        skillCorou1 = StartCoroutine(AroundShot());
    }

    IEnumerator AroundShot()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 6; j <= 60; j++)
            {
                GameObject tempOb = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, j * 6 + 18 + i*10));
                if (tempOb != null)
                    tempOb.GetComponentInChildren<EnemyBullet>().bulletSpeed = 5;

            }
            yield return new WaitForSeconds(0.5f);
        }
        
        Invoke("BossThink", 5);
    }
    new private void OnDisable()
    {
        base.OnDisable();
        GameManager.uiManager.bossHPBar.fillAmount = (float)hp / maxHP;
        StopAllCoroutines();
        CancelInvoke();
        
    }
}
