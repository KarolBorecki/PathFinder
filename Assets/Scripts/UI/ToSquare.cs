using UnityEngine;

public class ToSquare : MonoBehaviour
{
    public PanelResponsivityExpaneder.Size sizeToExpand; 
    
    private RectTransform _rt;
    
    private void Start()
    {
        _rt = gameObject.GetComponent<RectTransform>();

        Vector2 newSize;
        switch (sizeToExpand)
        {
            case PanelResponsivityExpaneder.Size.Height:
                newSize = new Vector2(_rt.sizeDelta.x, _rt.sizeDelta.x);
                break;
            case PanelResponsivityExpaneder.Size.Width:
                newSize = new Vector2(_rt.sizeDelta.y, _rt.sizeDelta.y);
                break;
            
            default:
                newSize = Vector2.zero;
                break;
        }

        _rt.sizeDelta = newSize;
    }
}
