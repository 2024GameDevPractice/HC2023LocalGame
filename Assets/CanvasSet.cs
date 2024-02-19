using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSet : MonoBehaviour
{
    static CanvasSet canvas;
    void Start()
    {
        if (canvas == null)
        {
            canvas = this;
            DontDestroyOnLoad(canvas);
            GameManager.Instance.ScoreBoard = transform.GetChild(3).gameObject;
        }
        else
            Destroy(gameObject);
    }
}
