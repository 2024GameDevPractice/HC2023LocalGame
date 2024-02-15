using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPos_Meteor;
    public bool isMonsterMeteor;
    [SerializeField] private GameObject monsterMeteor;

    GameObject tempOb;
    void Update()
    {
        if (!isMonsterMeteor)
        {
            int randomPos = Random.Range(0, spawnPos_Meteor.Length);
            StartCoroutine(Spawn_M(randomPos));
        }
    }

    IEnumerator Spawn_M(int randomPos)
    {
        isMonsterMeteor = true;
        yield return new WaitForSeconds(Random.Range(15f, 30f));
        switch (randomPos)
        {
            case 0:
                tempOb = Instantiate(monsterMeteor, spawnPos_Meteor[randomPos].position, Quaternion.Euler(new Vector3(0f, 0f, 65f)));
                break;
            case 1:
                tempOb = Instantiate(monsterMeteor, spawnPos_Meteor[randomPos].position, Quaternion.Euler(new Vector3(0f, 0f, -65f)));
                break;
            case 2:
                tempOb = Instantiate(monsterMeteor, spawnPos_Meteor[randomPos].position, Quaternion.Euler(new Vector3(0f, 0f, 32.5f)));
                break;
            case 3:
                tempOb = Instantiate(monsterMeteor, spawnPos_Meteor[randomPos].position, Quaternion.Euler(new Vector3(0f, 0f, -32.5f)));
                break;
            case 4:
                tempOb = Instantiate(monsterMeteor, spawnPos_Meteor[randomPos].position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                break;
        }
        tempOb.transform.parent = transform;
        isMonsterMeteor = false;

    }
}
