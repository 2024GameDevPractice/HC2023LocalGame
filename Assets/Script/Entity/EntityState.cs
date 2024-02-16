using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityState : MonoBehaviour
{
    

    //ÄÄÆ÷³ÍÆ®
    private SpriteRenderer spriteRenderer;
    protected Rigidbody2D rigid;
    protected Animator anim;

    //Á¤º¸ º¯¼ö
    protected int speed;
    public int hp;
    public bool isHit;

    //ÄðÅ¸ÀÓ°ú Äð´Ù¿î
    protected float cooltime;
    protected float cooldown = 0f;

    private Coroutine coroutine;
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
        if(coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(Hit());
        Die();
    }

    protected virtual void Die()
    {
        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator Hit()
    {
        spriteRenderer.color = Color.red;
        isHit = true;
        DestroyBullet();
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
        isHit = false;
    }

    protected virtual void DestroyBullet()
    {
    }
}
