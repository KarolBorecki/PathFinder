using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopElement{
    public string name;
    [HideInInspector]
    public Shop.ShopCategory category;
    public int price;
    public bool isOwned;
    public Sprite elementInShopImg;

}
