using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCard : RegularShopCard
{
    public override void Buy()
    {
        if (isBought) return;
        base.Buy();
        
    } 
}
