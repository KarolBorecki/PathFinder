using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinCard : ChooseableShopCard
{
    public static ChooseableShopCard actualChoosen;

    void Start()
    {
        actualChoosen = shopCategoryManager.cardsParent.transform.GetChild(0).GetComponent<ChooseableShopCard>();
        actualChoosen.Choose();
    }

    public override void Choose()
    {
        base.Choose();

        if (actualChoosen != this)
            actualChoosen.Unchoose();
        actualChoosen = this;
    }
}
