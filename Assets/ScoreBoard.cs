using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0f;

        transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Clear Time : " + (int)(GameManager.Instance.playTime / 60) + "m " + (int)(GameManager.Instance.playTime % 60) + "s";
        transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Remain Life : " + GameManager.Instance.playerController.hp;
        transform.GetChild(0).transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = "Stage Score : " + GameManager.Instance.score;

        transform.GetChild(0).transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = "Score Result : " + (GameManager.Instance.score + (GameManager.Instance.playerController.hp * 1000));
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
        GameManager.Instance.score = GameManager.Instance.score + (GameManager.Instance.playerController.hp * 1000);
    }
}
