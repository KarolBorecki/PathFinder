using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkinShopElement : ShopElement
{
    public Sprite newPlayerLook;
    public Color trailcolor = new Color(1, 1, 1, 1f);

    public float scale = .5f;
}
