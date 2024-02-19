using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnS : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPos_S;
    public bool isMonsterS;
    [SerializeField] private GameObject monsterS;

    void Update()
    {

        if (!isMonsterS && !GameManager.Instance.isBoss)
        {
            int randomPos = Random.Range(0, spawnPos_S.Length);
            StartCoroutine(Spawn_S(randomPos));
        }
    }

    IEnumerator Spawn_S(int randomPos)
    {
        isMonsterS = true;
        yield return new WaitForSeconds(3f);
        GameObject tempOb = Instantiate(monsterS, spawnPos_S[randomPos].position, transform.rotation);
        GameManager.Instance.monsterCount ++;

        for (int i = 1; i <= 10; i++)
        {
            tempOb.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f * i);
            yield return new WaitForSeconds(0.01f);
        }

        tempOb.transform.parent = transform;
    }
}
