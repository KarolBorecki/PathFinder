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
    public ShopCategoryManager playerCategoryManager;
    public ShopCategoryManager themesCategoryManager;
    public ShopCategoryManager obstaclesCategoryManager;
    public ShopCategoryManager powerUpCategoryManager;

    public PlayerShopElement[] playerShopElements;

    void Awake()
    {
        foreach (ShopElement se in playerShopElements)
            se.category = ShopCategory.Player;
        playerCategoryManager.elements = playerShopElements;
        
    }

    void Update()
    {
        
    }
}
