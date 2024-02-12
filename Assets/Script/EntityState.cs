using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    //이동시 속도
    private int speed;
    //플레이어에겐 내구도, 몬스터에겐 체력
    private int hp;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [ContextMenu("Hitt")]
    void Hitt()
    {
        StartCoroutine(Hit());
    }
    IEnumerator Hit()
    {
        spriteRenderer.color = new Color(1,0,0,0.5f);
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
    }
}
