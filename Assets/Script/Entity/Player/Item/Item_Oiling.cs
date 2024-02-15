using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Oiling : Item
{
    public override void Effect()
    {
        GameManager.Instance.playerFuel = 200;
    }
}
