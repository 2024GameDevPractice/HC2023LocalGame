using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    Rigidbody2D rigid;
    private int scrollSpeed = 8;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigid.velocity = Vector3.down * scrollSpeed;
        if (transform.position.y <= -21.59f)
            transform.position = new Vector3(0, 21.59f, 0f);
    }
}
