using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCard : MonoBehaviour
{
    public ShopCategoryManager shopCategoryManager;

    public ShopElement actualElement;
    public Image elementImage;
    public Text priceTag;


    public void LoadElement(ShopElement newElement)
    {
        actualElement = newElement;
        elementImage.sprite = newElement.elementInShopImg;
        elementImage.color = newElement.color;
        SetPriceTag(newElement.price);
    }

    public void SetPriceTag(int price = -10){
      if(price == -10) price = actualElement.price;
      priceTag.text = price + "$";
    }

    public virtual void Buy()
    {
        if (actualElement.level >= ShopElement.MAXLEVEL) return;
        if (!shopCategoryManager.shop.gameController.ShopElementBuy(actualElement.price)) return;
        actualElement.AddLevel();

        SetUpNewElement();
    }

    public void SetUpNewElement()
    {
        Shop.ShopCategory selfCategory = shopCategoryManager.category;
        if (selfCategory == Shop.ShopCategory.Skins)
            shopCategoryManager.shop.SetNewPlayer((SkinShopElement)actualElement);
        else if(selfCategory == Shop.ShopCategory.Player)
            shopCategoryManager.shop.UpgradePlayer((PlayerShopElement)actualElement);
    }
}
