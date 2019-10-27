using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegularShopCard : ShopCard
{
    public bool isBought;
    public Sprite soldSign;

    public override void Buy()
    {
        if (isBought) return;
        base.Buy();
        if (actualElement.level > 0)
        {
            isBought = true;
            elementImage.color = new Color(1, 1, 1, .01f);
            GetComponent<Button>().enabled = false;
            GetComponent<Image>().sprite = soldSign;
        }
    }
}
