using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShopCard : UpgradeableShopCard
{
    public override void Buy(){
      int lvl = actualElement.level;
      base.Buy();
      if(lvl<actualElement.level)
        Upgrade();
    }

    public override void Upgrade(){
      base.Upgrade();
      base.SetUpNewElement();
      SetPriceTag();
    }

}
