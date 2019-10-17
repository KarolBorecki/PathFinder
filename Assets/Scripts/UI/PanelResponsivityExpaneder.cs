using System.Collections.Generic;
using UnityEngine;

public class PanelResponsivityExpaneder : MonoBehaviour
{
    public enum Size
    {
        Width,
        Height
    }

    public Size sizeToExpand;
    public List<float> eachChildrenPartSize;
    public List<RectTransform> childrenToExpand;

    private float _sizeOfSide;
    
    private void Start()
    {
        switch (sizeToExpand)
        {
            case Size.Height:
               for(int i = 0; i<=childrenToExpand.Count-1; i++)
                   childrenToExpand[i].sizeDelta = new Vector2(childrenToExpand[i].sizeDelta.x, Screen.height* eachChildrenPartSize[i]);
               break;
            case Size.Width:
               for(int i = 0; i<=childrenToExpand.Count-1; i++)
                   childrenToExpand[i].sizeDelta = new Vector2(Screen.width* eachChildrenPartSize[i],childrenToExpand[i].sizeDelta.y);
               break;
            
            default:
                break;
        }
    }
}
