using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCard : MonoBehaviour
{
    public ShopCategoryManager shopCategoryManager; 
    
    public ShopElement actualElement;
    public Text elementText;
    public Image elementImage;
    public Text priceTag;

    public void LoadElement(ShopElement newElement)
    {
        actualElement = newElement;
        elementText.text = newElement.name;
        elementImage.sprite = newElement.elementInShopImg;
        priceTag.text = newElement.price + "$"; 
    }

}
