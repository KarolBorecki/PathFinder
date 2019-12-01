using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    public int textNumber;
    public string textBefore;
    public Text handledText;

    public float t = .5f;
    public int _desiredText;

    private float _at;

    private void Start()
    {
        _at = t;
        _desiredText = textNumber;
    }
    
    private void Update()
    {
        if (_desiredText == textNumber) return;
        _at -= Time.unscaledTime;
        if (_at > 0) return;
        
        if (textNumber < _desiredText)
        {
            handledText.text = textBefore + (textNumber + 1).ToString();
            textNumber+=1;
            _at = t;
        }else if (textNumber > _desiredText)
        {
            handledText.text = textBefore + (textNumber - 1).ToString();
            textNumber-=1;
            _at = t;
        }
    }
    
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
        //_desiredText = number;
        ImmediatelySetText(number);
    }

    public void ImmediatelySetText(int number)
    {
        textNumber = number;
        _desiredText = number;
        handledText.text = textBefore + textNumber;
    }
}
