using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public enum ShopCategory
    {
        Skins,
        Themes,
        Obstacles,
        PowerUps
    }

    public GameController gameController;
    public TextHandler moneyText;

    public ChooseableShopCard actualChoosenSkin;
    public SpriteRenderer player;
    public TrailRenderer playerTrail;

    public ShopCategoryManager skinsManager;
    public ShopCategoryManager themesManager;
    public ShopCategoryManager obstaclesManager;
    public ShopCategoryManager powerUpManager;

    public SkinShopElement[] skinsShopElements;
    public ThemeShopElement[] themeShopElements;
    public ObstacleShopElement[] obstacleShopElements;
    public PowerUpShopelement[] powerUpShopElements;

    void Awake()
    {
        foreach (ShopElement se in skinsShopElements)
            se.category = ShopCategory.Skins;
        skinsManager.elements = skinsShopElements;

        foreach (ShopElement se in themeShopElements)
            se.category = ShopCategory.Themes;
        themesManager.elements = themeShopElements;

        foreach (ShopElement se in obstacleShopElements)
            se.category = ShopCategory.Obstacles;
        obstaclesManager.elements = obstacleShopElements;

        foreach (ShopElement se in powerUpShopElements)
            se.category = ShopCategory.PowerUps;
        powerUpManager.elements = powerUpShopElements;

    }

    public void SetNewPlayer(SkinShopElement newPlayer)
    {
        player.GetComponent<SpriteRenderer>().color = new Color(newPlayer.color.r, newPlayer.color.g, newPlayer.color.b);
        playerTrail.startColor = new Color(newPlayer.color.r, newPlayer.color.g, newPlayer.color.b);
        playerTrail.endColor = new Color(newPlayer.color.r, newPlayer.color.g, newPlayer.color.b, 0);
        player.sprite = newPlayer.newPlayerLook;
    }
}
