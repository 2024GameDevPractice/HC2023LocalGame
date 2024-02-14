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
    
    

    public int repairCount;
    public int missileCount;
}
