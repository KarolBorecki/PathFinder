using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Shop;

public class ShopMenu : MonoBehaviour
{
    public static Text actualCard;

    public List<Text> categoryCards;

    public void Start()
    {
        SetCategory(categoryCards[0]);
    }

    public void SetCategory(Text card)
    {
        if(actualCard != null)
            UnSetCategory(actualCard);
        card.color = new Color(1, 1, 1, .1f);
        actualCard = card;
    }

    private void UnSetCategory(Text card)
    {
        card.color = new Color(1, 1, 1, 1);
    }

}
