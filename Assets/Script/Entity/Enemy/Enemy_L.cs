using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_L : Enemy
{
    [SerializeField] private Transform spawnPos_L;
    int direction = 1;
    int time = 2;
    protected override void Init()
    {
        damage = 1;
        speed = 5;
        spawnPos_L = GameObject.Find("L_Pos").transform.GetChild(1);
    }
    private void Start()
    {
        StartCoroutine(Move_());
        StartCoroutine(Shoot_());
    }
    protected IEnumerator Move_()
    {
        if (time == 2)
            yield return new WaitForSeconds(2f);
        else
            yield return new WaitForSeconds(4f);
        direction *= -1; time = 1;
        StartCoroutine(Move_());
    }

    protected IEnumerator Shoot_()
    {
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 105)));
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 75)));
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Shoot_());
    }
    private void OnDisable()
    {
        transform.parent.GetComponent<EnemySpawnL>().isMonsterL = false;
    }
    protected override void Shoot()
    {

    }

    protected override void Move()
    {
        rigid.velocity = transform.right * speed * direction;
    }
}
