using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCategoryManager : MonoBehaviour
{

    public Shop.ShopCategory category;
    public ShopElement[] elements;
    public ShopCard shopCard;
    public RectTransform cardsParent;

    private int _elementIndex;

    void Start()
    {
        LoadContent();
    }

    public void LoadContent()
    {
        int i = 0;
        foreach(ShopElement se in elements)
        {
            ShopCard newElementCard = Instantiate(shopCard, cardsParent);
            newElementCard.LoadElement(elements[i]);
            ++i;
        }
    }

}
