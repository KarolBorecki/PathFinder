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
        priceTag.text = newElement.price + "$"; 
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
        if (selfCategory == Shop.ShopCategory.Player)
            shopCategoryManager.shop.SetNewPlayer((PlayerShopElement)actualElement);
    }
}
