using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_M : Enemy
{
    static int z;
    float timer;
    bool isRot;
    protected override void Init()
    {
        speed = 7;
        cooltime = 0.8f;
        hp = 30;
        damage = 1;
    }

    protected override void Move()
    {
        rigid.velocity = -transform.up * speed;
    }
    private new void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (timer > 1.5f && !isRot)
        {
            StartCoroutine(Rotation());
        }
    }

    IEnumerator Rotation()
    {
        isRot = true;
        for (; ; )
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
    protected override void Shoot()
    {
        cooldown += Time.deltaTime;
        if (cooltime <= cooldown)
        {
            GameObject tempOb = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 90f)));
            tempOb.transform.position = transform.position + (-transform.up * 0.8f);
            tempOb.transform.GetChild(0).GetComponent<EnemyBullet>().bulletSpeed = speed + 1;
            tempOb.transform.GetChild(0).localRotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z));
            cooldown = 0f;
        }
    }
}
