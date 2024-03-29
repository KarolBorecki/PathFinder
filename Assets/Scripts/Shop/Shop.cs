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
    public SpriteRenderer playerSprite;
    public TrailRenderer playerTrail;

    public PlayerController playerController;
    public Player player;
    public EnergyBar energyBar;

    public EnvironmentGenerator enviromentGenerator;
    public SideGenerator sideGenerator;

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
        playerSprite.GetComponent<SpriteRenderer>().color = new Color(newPlayer.color.r, newPlayer.color.g, newPlayer.color.b);
        playerTrail.startColor = new Color(newPlayer.trailcolor.r, newPlayer.trailcolor.g, newPlayer.trailcolor.b, 1);
        playerTrail.endColor = new Color(newPlayer.trailcolor.r, newPlayer.trailcolor.g, newPlayer.trailcolor.b, 0);
        playerSprite.sprite = newPlayer.newPlayerLook;
        playerSprite.transform.localScale = new Vector3(newPlayer.scale, newPlayer.scale, newPlayer.scale);
    }

    public void UpgradePlayer(PlayerShopElement element){
      element.price =(int)(element.price*element.priceMultiplayer);
      if(element.playerfeature == PlayerShopElement.PlayerFeature.Force)
        playerController.moveForce *= element.multiplayer;
      else if(element.playerfeature == PlayerShopElement.PlayerFeature.Shield)
        player.shieldTime *= element.multiplayer;
      else if(element.playerfeature == PlayerShopElement.PlayerFeature.AimingCost)
        player.GetComponent<PlayerAim>().slowDownEnergyDecrease *= element.multiplayer;
      else if(element.playerfeature == PlayerShopElement.PlayerFeature.EnergyAmount){
        player.maxEnergy = (int)(player.maxEnergy * element.multiplayer);
        player.energy = player.maxEnergy;
        energyBar.Setup();
      }
    }

    public Sprite UpgradePowerUp(PowerUpShopelement powerUp){
        powerUp.price =(int)(powerUp.price*powerUp.priceMultiplayer);
        powerUp.powerUpPrefab.number = (int)(powerUp.powerUpPrefab.number*powerUp.multiplayer);
        if(powerUp.level==1)
          enviromentGenerator.AddNewPowerUp(powerUp.powerUpPrefab);
        return powerUp.spriteAfterBuying;
    }

    public void AddObstacles(ObstacleShopElement element)
    {
        sideGenerator.elements.AddRange(element.obstacles);
    }
}
