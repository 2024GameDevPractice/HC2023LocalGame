using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHp;
    public GameObject glare;
    public Coroutine glareCorou;
    private void Start()
    {
        playerHp = GameObject.Find("HPCount").GetComponent<TextMeshProUGUI>();
        glare = GameObject.Find("Glare");
    }
    private void Update()
    {
        playerHp.text = "X " + GameManager.Instance.playerController.hp;
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
