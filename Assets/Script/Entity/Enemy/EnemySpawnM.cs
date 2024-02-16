using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnM : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPos_M;
    public bool isMonsterM;
    [SerializeField] private GameObject monsterM;
    void Update()
    {
        if (!isMonsterM && !GameManager.Instance.isBoss)
        {
            int randomPos = Random.Range(0, spawnPos_M.Length);
            StartCoroutine(Spawn_M(randomPos));
        }
    }

    IEnumerator Spawn_M(int randomPos)
    {
        GameObject tempOb;
        isMonsterM = true;
        yield return new WaitForSeconds(Random.Range(5f, 15f));
        if(randomPos == 0)
        {
            tempOb = Instantiate(monsterM, spawnPos_M[randomPos].position, Quaternion.Euler(new Vector3(0f, 0f, 65f)));
        }
        else
        {
            tempOb = Instantiate(monsterM, spawnPos_M[randomPos].position, Quaternion.Euler(new Vector3(0f, 0f, -65f)));
        }
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 0; j < tempOb.transform.childCount; j++)
            {
                tempOb.transform.GetChild(j).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f * i);
            }
            yield return new WaitForSeconds(0.02f);
        }
        tempOb.transform.parent = transform;
        isMonsterM = false;

    }
}
