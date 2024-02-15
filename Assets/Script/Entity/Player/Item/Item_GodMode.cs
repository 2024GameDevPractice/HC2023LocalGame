using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_GodMode : Item
{
    public override void Effect()
    {
        GameManager.Instance.godTime = 0;
    }
}
