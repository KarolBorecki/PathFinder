using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinCard : ChooseableShopCard
{
    public static ChooseableShopCard actualChoosen;

    void Start()
    {
        SkinCard.actualChoosen = shopCategoryManager.cardsParent.transform.GetChild(0).GetComponent<ChooseableShopCard>();
        SkinCard.actualChoosen.Choose();
    }

    public override void Choose()
    {
        if(isChoosen) return;
        base.Choose();
        if (SkinCard.actualChoosen != this && isBought)
            SkinCard.actualChoosen.Unchoose();
        SkinCard.actualChoosen = this;
    }
}
