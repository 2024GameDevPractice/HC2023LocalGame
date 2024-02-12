using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityState
{
    // ������Ʈ
    Rigidbody2D rigid;
    private Animator anim;

    // ���� ����
    private int playerSpeed = 8;

    // �Ѿ� ������Ʈ
    public GameObject[] bullets;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameManager.Instance.player = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        anim.SetInteger("h", (int)h);

        rigid.velocity = new Vector3(h, v, 0) * playerSpeed;
    }
}
