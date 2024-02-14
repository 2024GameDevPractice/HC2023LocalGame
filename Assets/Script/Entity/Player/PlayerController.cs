using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : EntityState
{
    // 정보 변수
    public int playerLevel = 1;

    protected float repairCooltime = 3f;
    protected float repairCooldown = 0f;

    protected float missileCooltime = 3f;
    protected float missileCooldown = 0f;

    // 총알 오브젝트
    public GameObject[] bullets;
    [SerializeField] private GameObject missile;

    // 섬광 오브젝트
    private void Awake()
    {
        GameManager.Instance.player = gameObject.transform;
        GameManager.Instance.playerController = GetComponent<PlayerController>();
        transform.parent = GameManager.Instance.transform;
    }

    void Update()
    {
        Move();
        Shoot();
        Skill1();
        Skill2();
    }

    protected override void Init()
    {
        speed = 8;
        cooltime = 0.15f;
        hp = 10;

        repairCooltime = 3f;
        missileCooltime = 3f;
    }

    void Skill1()
    {
        missileCooldown += Time.deltaTime;
        Debug.Log(missileCooldown);
        if(missileCooltime <= missileCooldown)
        {
            Debug.Log("준비완료");
            if(Input.GetKeyDown(KeyCode.A))
            {
                Instantiate(missile, transform.position+(Vector3.up*0.8f), transform.rotation).GetComponent<Rigidbody2D>().velocity = Vector2.up * 5;
                missileCooldown = 0;
            }
            
        }
    }
    void Skill2()
    {

    }

    // 이동
    protected override void Move()
    {
        float h;
        float v;

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
            {
                Instantiate(bullets[playerLevel - 1], transform.position + new Vector3(0, 0.3f, 0), Quaternion.Euler(new Vector3(0, 0, 90f)));
                cooldown = 0f;
            }
        }
    }

    protected override void DestroyBullet()
    {
        
        GameObject[] e_bullet = GameObject.FindGameObjectsWithTag("E_Bullet");
        if (GameManager.uiManager.glareCorou == null)
        {
            GameManager.uiManager.glareCorou = StartCoroutine(GameManager.uiManager.Glare());
            Debug.Log(1);
        }
        foreach (var bullet in e_bullet)
        {
            Destroy(bullet);
        }
    }
}
