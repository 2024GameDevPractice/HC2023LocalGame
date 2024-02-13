using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityState : MonoBehaviour
{
    

    //������Ʈ
    private SpriteRenderer spriteRenderer;
    protected Rigidbody2D rigid;
    protected Animator anim;

    //���� ����
    protected int speed;
    public int hp;
    public bool isHit;

    //��Ÿ�Ӱ� ��ٿ�
    protected float cooltime;
    protected float cooldown = 0f;


    public void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(GetComponent<Animator>() != null )
            anim = GetComponent<Animator>();
        Init();
    }

    protected abstract void Init();
    protected abstract void Shoot();
    protected abstract void Move();

    [ContextMenu("Hitt")]
    public void Hitt()
    {
        StartCoroutine(Hit());
        Die();
    }

    void Die()
    {
        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator Hit()
    {
        spriteRenderer.color = new Color(1f,0,0);
        isHit = true;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
        isHit = false;
    }
}
