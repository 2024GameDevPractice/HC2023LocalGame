using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnL : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPos_L;
    public bool isMonsterL;
    [SerializeField] private GameObject monsterL;

    void Update()
    {

        if (!isMonsterL && !GameManager.Instance.isBoss)
        {
            int randomPos = Random.Range(0, spawnPos_L.Length);
            StartCoroutine(Spawn_L(randomPos));
        }
    }

    IEnumerator Spawn_L(int randomPos)
    {
        isMonsterL = true;
        yield return new WaitForSeconds(3f);
        GameObject tempOb = Instantiate(monsterL, spawnPos_L[1].position, transform.rotation);
        for (int i = 1; i <= 10; i++)
        {
            tempOb.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f * i);
            yield return new WaitForSeconds(0.03f);
        }

        tempOb.transform.parent = transform;
    }
}
