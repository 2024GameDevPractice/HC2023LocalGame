using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 5;
    }
    public abstract void Effect();
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
