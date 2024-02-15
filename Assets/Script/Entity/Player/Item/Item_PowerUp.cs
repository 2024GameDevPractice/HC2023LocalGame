using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_PowerUp : Item
{
    public override void Effect()
    {
        if (GameManager.Instance.playerController.playerLevel < 4)
            GameManager.Instance.playerController.playerLevel++;
        else GameManager.Instance.score += 500;
    }
}
