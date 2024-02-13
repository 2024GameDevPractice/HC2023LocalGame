using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityState
{
    // 정보 변수
    public int playerLevel = 1;

    
    // 총알 오브젝트
    public GameObject[] bullets;

    private void Awake()
    {
        GameManager.Instance.player = gameObject.transform;
        GameManager.Instance.playerController = this;
        transform.parent = GameManager.Instance.transform;
    }

    void Update()
    {
        Move();
        Shoot();
    }

    protected override void Init()
    {
        speed = 8;
        cooltime = 0.15f;
        hp = 100;
    }

    // 이동
    protected override void Move()
    {
        float h = 0;
        float v = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) h = -1;
        else if (Input.GetKey(KeyCode.RightArrow)) h = 1;
        else h = 0;

        if (Input.GetKey(KeyCode.UpArrow)) v = 1;
        else if (Input.GetKey(KeyCode.DownArrow)) v = -1;
        else v = 0;

        anim.SetInteger("h", (int)h);

        rigid.velocity = new Vector3(h, v, 0) * speed;
    }


    //  총알 발사
    protected override void Shoot()
    {
        cooldown += Time.deltaTime;
        if (cooltime <= cooldown)
        {
            if (Input.GetKey(KeyCode.X))
                Instantiate(bullets[playerLevel - 1], transform.position + new Vector3(0, 0.3f,0), Quaternion.Euler(new Vector3(0, 0, 90f)));
            cooldown = 0f;
        }
    }

    
}
