using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static UIManager uiManager;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject tempManager = new GameObject("GameManager");
                instance = tempManager.AddComponent<GameManager>();
                uiManager = tempManager.AddComponent<UIManager>();
                DontDestroyOnLoad(tempManager);
            }
            return instance;
        }
    }

    public Transform player;
    public PlayerController playerController;
    public float playerFuel;

    private void Update()
    {
        if(!isBossDead)
            playTime += Time.deltaTime;
        godTime += Time.deltaTime;
        if (godTime < 2)
        {
            isGod = true;
        }
        else
            isGod = false;
    }

    public enum Stage
    {
        Stage1,
        Stage2,
        Ranking
    }

    public Stage stageState;

    public GameObject ScoreBoard;

    public int repairCount;
    public int missileCount;
    public int score;

    public bool isBoss;
    public bool isBossDead;

    public bool isCheatGod;
    public bool isGod;

    public float godTime;

    public int monsterCount;
    public float playTime;
}
