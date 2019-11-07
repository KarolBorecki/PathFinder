﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public enum ShopCategory
    {
        Skins,
        Player,
        Obstacles,
        PowerUps
    }

    public GameController gameController;
    public TextHandler moneyText;

    public ChooseableShopCard actualChoosenSkin;
    public SpriteRenderer player;
    public TrailRenderer playerTrail;

    public PlayerController playerController;

    public ShopCategoryManager skinsManager;
    public ShopCategoryManager playerManager;
    public ShopCategoryManager obstaclesManager;
    public ShopCategoryManager powerUpManager;

    public SkinShopElement[] skinsShopElements;
    public PlayerShopElement[] playerShopElements;
    public ObstacleShopElement[] obstacleShopElements;
    public PowerUpShopelement[] powerUpShopElements;

    void Awake()
    {
        foreach (ShopElement se in skinsShopElements)
            se.category = ShopCategory.Skins;
        skinsManager.elements = skinsShopElements;

        foreach (ShopElement se in playerShopElements)
            se.category = ShopCategory.Player;
        playerManager.elements = playerShopElements;

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

    public void UpgradePlayer(PlayerShopElement element){
      element.price =(int)(element.price*element.priceMultiplayer);
      if(element.playerfeature == PlayerShopElement.PlayerFeature.Force)
        playerController.moveForce *= element.multiplayer;
    }
}
