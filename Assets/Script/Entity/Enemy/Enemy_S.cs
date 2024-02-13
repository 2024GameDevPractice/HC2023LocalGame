using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_S : Enemy
{
    private void Start()
    {
       // StartCoroutine(Rotation());
    }

    protected override void Init()
    {
        speed = 2;
        cooltime = 1f;
        hp = 50;
    }

    protected override void Move()
    {

    }

    protected override void Shoot()
    {
        cooldown += Time.deltaTime;
        if (cooltime <= cooldown)
        {
            GameObject tempOb = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 90f)));
            tempOb.transform.GetChild(0).GetComponent<EnemyBullet>().bulletSpeed = speed + 1;
            transform.LookAt(GameManager.Instance.player);
            tempOb.transform.GetChild(0).localRotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z));
            
            tempOb.transform.position = transform.position + (-transform.up * 0.8f);
            cooldown = 0f;
        }
    }

    private void OnDisable()
    {
        transform.parent.GetComponent<EnemySpawnS>().isMonsterS = false;
    }

    private IEnumerator Rotation()
    {
        int randomZ = Random.Range(-1, 2);
        for (int i = 0; i < 30; i++)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * randomZ));
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Rotation());
    }
}
