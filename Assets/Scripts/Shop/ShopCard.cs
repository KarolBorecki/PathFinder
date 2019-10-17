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

    public Transform levelPanel;
    public Sprite boughtLevelSprite;
    public Sprite notBoughtLevelSprite;


    public void SetLevelPanel()
    {
        int level = actualElement.level;
        for(int i = 0; i<ShopElement.MAXLEVEL; ++i)
        {
            Image childSprite = levelPanel.GetChild(i).GetComponent<Image>();
            if (level > 0)
                childSprite.sprite = boughtLevelSprite;
            else
                childSprite.sprite = notBoughtLevelSprite;
            --level;
        } 
    }

    public void LoadElement(ShopElement newElement)
    {
        actualElement = newElement;
        elementImage.sprite = newElement.elementInShopImg;
        priceTag.text = newElement.price + "$"; 
    }

    public void Buy()
    {
        if (actualElement.level >= ShopElement.MAXLEVEL) return;
        if (!shopCategoryManager.shop.gameController.ShopElementBuy(actualElement.price)) return;
        actualElement.AddLevel();
        SetLevelPanel();
        
    }

}
