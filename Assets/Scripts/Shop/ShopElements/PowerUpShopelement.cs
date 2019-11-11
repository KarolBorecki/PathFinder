using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpShopelement : ShopElement
{
    public PowerUp powerUpPrefab;
    public Sprite spriteAfterBuying;

    public float multiplayer = 1.1f;
    public float priceMultiplayer = 1.2f;
}
