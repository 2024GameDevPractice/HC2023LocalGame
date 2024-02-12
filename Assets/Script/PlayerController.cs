using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityState
{
    // 컴포넌트
    Rigidbody2D rigid;
    private Animator anim;

    // 정보 변수
    private int playerSpeed = 8;

    // 총알 오브젝트
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
