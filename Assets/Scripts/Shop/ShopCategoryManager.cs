using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCategoryManager : MonoBehaviour
{

    public Shop.ShopCategory category;
    public ShopElement[] elements;

    public ShopCard card;

    public Button RightButton;
    public Button LeftButton;

    private int _elementIndex;

    void Start()
    {
        card.shopCategoryManager = this;
        card.LoadElement(elements[_elementIndex]);

        CheckButtons();
    }

    public void LoadNew(bool right)
    {
        _elementIndex += right ? 1 : -1;
        card.LoadElement(elements[_elementIndex]);

        CheckButtons();
    }

    private void CheckButtons()
    {
        RightButton.interactable = true;
        LeftButton.interactable = true;
        if (_elementIndex >= elements.Length - 1) RightButton.interactable = false;
        else if (_elementIndex <= 0) LeftButton.interactable = false;

        RightButton.transform.GetChild(0).gameObject.SetActive(RightButton.interactable);
        LeftButton.transform.GetChild(0).gameObject.SetActive(LeftButton.interactable);
    }

}
