using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed;
    public int damage;

    protected Rigidbody2D rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
        if(transform.parent != null)
        {
            Destroy(transform.parent.gameObject, 10f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("EnemyWall"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
