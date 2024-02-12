using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    //�̵��� �ӵ�
    private int speed;
    //�÷��̾�� ������, ���Ϳ��� ü��
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
