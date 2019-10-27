using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopElement{
    public const int MAXLEVEL = 5;
    public string name;
    [HideInInspector]
    public Shop.ShopCategory category;
    public int price;
    public int level;
    public Sprite elementInShopImg;
    public Color color = new Color(1,1,1,1f);

    public void AddLevel()
    {
        if (level < MAXLEVEL) level++;
    }

}
