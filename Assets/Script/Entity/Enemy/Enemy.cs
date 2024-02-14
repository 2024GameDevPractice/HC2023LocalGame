using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : EntityState
{
    //���� ������
    protected int damage;

    //�Ѿ� ������Ʈ
    [SerializeField] protected GameObject bullet;

    public void Update()
    {
        Move();
        Shoot();
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
}
