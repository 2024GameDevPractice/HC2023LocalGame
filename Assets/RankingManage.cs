using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankingManage : MonoBehaviour
{
    static List<Rank> ranking;

    public TextMeshProUGUI scocore;

    public Button register;
    public TMP_InputField nameInput;

    [SerializeField] private TextMeshProUGUI[] rank_Name;
    [SerializeField] private TextMeshProUGUI[] rank_Score;
    private int countList;

    private void Start()
    {
        scocore.text = "Score : " + GameManager.Instance.score;

        if (ranking == null)
            ranking = new List<Rank>();
        else
        {
            if (ranking.Count >= 3)
            {
                countList = 3;
            }
            else countList = ranking.Count;
            ranking.Sort((a, b) => { return b.score - a.score; }) ;
            for(int i = 0; i < countList; i++) 
            {
                rank_Name[i].text = ranking[i].name;
                rank_Score[i].text = ranking[i].score.ToString();
            }
        }
    }

    public void RegisterRanking()
    {
        AddRank(nameInput.text);
        register.interactable = false;

        if (ranking.Count >= 3)
        {
            countList = 3;
        }
        else countList = ranking.Count;

        ranking.Sort((a, b) => { return b.score - a.score; });
        for (int i = 0; i < countList; i++)
        {
            rank_Name[i].text = ranking[i].name;
            rank_Score[i].text = ranking[i].score.ToString();
        }
    }

    void AddRank(string name)
    {
        ranking.Add(new Rank(name, GameManager.Instance.score));
    }
}

class Rank
{
    public string name;
    public int score;

    public Rank(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
