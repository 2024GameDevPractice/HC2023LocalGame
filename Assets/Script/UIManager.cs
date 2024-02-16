using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerHp;
    public Slider playerFuel;


    public GameObject glare;
    public Coroutine glareCorou;

    public Image skill1;
    public TextMeshProUGUI skill1Count;
    public Image skill2;
    public TextMeshProUGUI skill2Count;

    public Image bossHPBar;
    public GameObject bossHP;

    private void Start()
    {
        playerHp = GameObject.Find("HPCount").GetComponent<TextMeshProUGUI>();
        playerFuel = GameObject.Find("Fuel").GetComponent<Slider>();

        skill1 = GameObject.Find("MissileCoolDown").GetComponent<Image>();
        skill1Count = GameObject.Find("MissileCount").GetComponent<TextMeshProUGUI>();
        skill2 = GameObject.Find("RepairCoolDown").GetComponent<Image>();
        skill2Count = GameObject.Find("RepairCount").GetComponent<TextMeshProUGUI>();

        bossHP = GameObject.Find("BossHP");
        bossHPBar = GameObject.Find("BossHPFill").GetComponent<Image>();
        if (GameObject.Find("Boss1") == null && GameObject.Find("Boss2") == null)
        {
            GameManager.Instance.isBoss = false;
            bossHP.SetActive(false);
        }
        else
            GameManager.Instance.isBoss = true;

        glare = GameObject.Find("Glare");
    }
    private void Update()
    {
        playerHp.text = "X " + GameManager.Instance.playerController.hp;
        playerFuel.value = GameManager.Instance.playerFuel / 200;
        GameManager.Instance.playerFuel -= Time.deltaTime;

        skill1.fillAmount = 1 - GameManager.Instance.playerController.missileCooldown / GameManager.Instance.playerController.missileCooltime;
        skill1Count.text = "X " + GameManager.Instance.missileCount;
        skill2.fillAmount = 1 - GameManager.Instance.playerController.repairCooldown / GameManager.Instance.playerController.repairCooltime;
        skill2Count.text = "X " + GameManager.Instance.repairCount;
    }



    public IEnumerator Glare()
    {
        Image image = glare.GetComponent<Image>();
        image.color = Color.white;
        for (int i = 10; i >= 0; i--)
        {
            image.color = new Color(1, 1, 1, i * 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
        glareCorou = null;

    }
}
