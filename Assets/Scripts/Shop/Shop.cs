using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public enum ShopCategory
    {
        Player,
        Themes,
        Obstacles,
        PowerUps
    }
    public ShopCategoryManager playerManager;
    public ShopCategoryManager themesManager;
    public ShopCategoryManager obstaclesManager;
    public ShopCategoryManager powerUpManager;

    public PlayerShopElement[] playerShopElements;
    public ThemeShopElement[] themeShopElements;
    public ObstacleShopElement[] obstacleShopElements;
    public PowerUpShopelement[] powerUpShopElements;

    void Awake()
    {
        foreach (ShopElement se in playerShopElements)
            se.category = ShopCategory.Player;
        playerManager.elements = playerShopElements;

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

    void Update()
    {
        
    }
}
