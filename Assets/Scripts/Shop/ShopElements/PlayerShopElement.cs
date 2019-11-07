using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerShopElement : ShopElement
{
  public enum PlayerFeature{
    Force,
    Shield,
    AimingCost,
    EnergyAmount
  }
  public PlayerFeature playerfeature;
  public float multiplayer = 1.1f;
  public float priceMultiplayer = 1.2f;
}
