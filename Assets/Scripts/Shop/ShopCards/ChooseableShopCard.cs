using UnityEngine;
using UnityEngine.UI;

public class ChooseableShopCard : ShopCard
{

    public bool isBought;
    public bool isChoosen;
    public Sprite chooseSign;

    public virtual void Choose()
    {
        Buy();
        if (!isBought) return;

        base.SetUpNewElement();
        isChoosen = true;
        elementImage.color = new Color(actualElement.color.r, actualElement.color.g, actualElement.color.b, .01f);
        GetComponent<Button>().enabled = false;
        GetComponent<Image>().sprite = chooseSign;
    }

    public override void Buy()
    {
        if (isBought) return;
        base.Buy();
        if(!(actualElement.level>0)) return;
        priceTag.text = "Bought!";
        priceTag.color = new Color(0,1,0, .1f);
        isBought = true;
    }

    public virtual void Unchoose()
    {
        isChoosen = false;
        elementImage.color = new Color(actualElement.color.r, actualElement.color.g, actualElement.color.b, 1);
        GetComponent<Button>().enabled = true;
        GetComponent<Image>().sprite = null;
    }
}
