using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Repair : Item
{
    public override void Effect()
    {
        if (GameManager.Instance.playerController.hp < 10)
            GameManager.Instance.playerController.hp++;
    }
}
