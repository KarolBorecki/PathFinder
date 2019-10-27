using UnityEngine;
using UnityEngine.UI;

public class UpgradeableShopCard : ShopCard
{
    public Transform levelPanel;

    public Sprite boughtLevelSprite;
    public Sprite notBoughtLevelSprite;

    public override void Buy()
    {
        base.Buy();
        SetLevelPanel();
    }

    private void SetLevelPanel()
    {
        int level = actualElement.level;
        for (int i = 0; i < ShopElement.MAXLEVEL; ++i)
        {
            Image childSprite = levelPanel.GetChild(i).GetComponent<Image>();
            if (level > 0)
                childSprite.sprite = boughtLevelSprite;
            else
                childSprite.sprite = notBoughtLevelSprite;
            --level;
        }
    }
}
