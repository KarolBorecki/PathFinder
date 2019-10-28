using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    public int textNumber;
    public string textBefore;
    public Text handledText;

    public void Increase(int amount)
    {
        textNumber += amount;
        SetText(textNumber);
    }

    public void Decrease(int amount)
    {
        textNumber -= amount;
        SetText(textNumber);
    }
    
    public void SetTextAsCombo(int comboAmount)
    {
        if (comboAmount > 1)
        {
            textNumber = comboAmount;
            SetText(textNumber);
        }
        else handledText.text = " ";
    }

    public void SetText(int number)
    {
        handledText.text = textBefore + number;
    }
}
