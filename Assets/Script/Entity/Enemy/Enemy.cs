using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : EntityState
{
    //접촉 데미지
    protected int damage;

    //총알 오브젝트
    [SerializeField] protected GameObject bullet;

    [SerializeField] protected GameObject[] items;
    public int enumScore;

    public void Update()
    {
        Move();
        Shoot();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().hp -= damage;
            other.GetComponent<PlayerController>().Hitt();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("EnemyWall"))
        {
            Destroy(gameObject, 0.5f);
            if (gameObject.transform.parent != null)
                Destroy(gameObject.transform.parent.gameObject, 0.5f);
        }
    }

    protected override void Die()
    {
        if (hp <= 0)
        {
            ItemSpawn();
            if (gameObject != null)
            {
                Destroy(gameObject);
                GameManager.Instance.score += enumScore;
            }
        }
    }
    void ItemSpawn()
    {
        int temSpawn = Random.Range(0, 5);
        if (temSpawn == 0)
        {
            int item = Random.Range(0, items.Length + 1);
            if (item == 4)
                item = 1;
            Instantiate(items[item], transform.position, Quaternion.identity);
        }
    }
}
