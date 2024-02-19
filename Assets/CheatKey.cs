using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatKey : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Enemy[] Enemys = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in Enemys)
            {
                enemy.hp = 0;
                enemy.Hitt();
            }
        }

        else if (Input.GetKeyDown(KeyCode.F2))
        {
            GameManager.Instance.playerController.playerLevel = 4;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            GameManager.Instance.missileCount = 5;
            GameManager.Instance.repairCount = 3;
            GameManager.Instance.playerController.repairCooldown = 3f;
            GameManager.Instance.playerController.missileCooldown = 3f;
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            GameManager.Instance.playerController.hp = 10;
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            GameManager.Instance.playerFuel = 200;
        
        }else if (Input.GetKeyDown(KeyCode.F6))
        {
            if(GameManager.Instance.stageState == GameManager.Stage.Stage1)
                SceneManager.LoadScene("Stage2");
            else
                SceneManager.LoadScene("Stage1");
        }

    }
}
