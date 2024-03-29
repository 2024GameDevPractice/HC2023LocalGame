using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : Skill
{
    public GameObject explode;
    public override void Init()
    {
        use_Time = 0.25f;
        skillName = "missile";
    }

    public override void Play()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("E_Bullet");
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
        foreach (GameObject enemy in objects)
        {
            enemy.GetComponent<Enemy>().hp -= GameManager.Instance.playerController.playerLevel * 20;
            enemy.GetComponent<Enemy>().Hitt();
        }
        GameObject tempOb = Instantiate(explode, transform.position, transform.rotation);
        Destroy(tempOb, 0.5f);
        Destroy(gameObject);
    }
}
