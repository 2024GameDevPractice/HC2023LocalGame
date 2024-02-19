using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSet : MonoBehaviour
{
    public GameManager.Stage stageSelect;
    public int bossCount;
    public GameObject boss;
    void Start()
    {
        GameManager.Instance.stageState = stageSelect;
        if(GameManager.Instance.stageState == GameManager.Stage.Stage1)
        {
            GameManager.uiManager.Start();
        }

    }
    private void Update()
    {
        if (bossCount <= GameManager.Instance.monsterCount && !GameManager.Instance.isBossDead)
        {
            boss.SetActive(true);
        }
    }

    public void SceneMove()
    {
        GameManager.Instance.ScoreBoard.SetActive(false);
        GameManager.Instance.missileCount = 5;
        GameManager.Instance.repairCount = 3;

        if (GameManager.Instance.stageState == GameManager.Stage.Stage1)
            SceneManager.LoadScene("Stage2");
        else if (GameManager.Instance.stageState == GameManager.Stage.Stage2)
            SceneManager.LoadScene("RankingPage");
        else
            SceneManager.LoadScene("MainMenu");
    }

}
