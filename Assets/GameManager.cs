using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject tempGM = new GameObject("GameManager");
                instance = tempGM.AddComponent<GameManager>();
                DontDestroyOnLoad(tempGM);
            }
            return instance;
        }
    }

    public Transform player;
}
