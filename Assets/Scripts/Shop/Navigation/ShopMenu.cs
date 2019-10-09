using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Shop;

public class ShopMenu : MonoBehaviour
{
    public ShopCategory category;

    public List<GameObject> categoryCards; 
    
    void Start()
    {
    }

    void Update()
    {
    }


    public void SetCategory(ShopCategory newCategory)
    {
        category = newCategory;
        HideAllCards();

        switch (category)
        {
            case ShopCategory.Player:
                categoryCards[0].SetActive(true);
                break;
            case ShopCategory.Themes:
                categoryCards[1].SetActive(true);
                break;
            case ShopCategory.Obstacles:
                categoryCards[2].SetActive(true);
                break;
            case ShopCategory.PowerUps:
                categoryCards[3].SetActive(true);
                break;
            default:
                break;
        }
    }

    public void HideAllCards()
    {
        for (int i = 0; i < categoryCards.Count; i++)
            categoryCards[i].SetActive(false);
    }
}