using UnityEngine;

public class Responsivity : MonoBehaviour
{
    public enum Side
    {
        Right,Left,Bottom, Top
    }

    public Side side;
    public float margin;

    public bool setAtStart = true;
    
    public Vector2 maxPositions;
    
    private void Start()
    {
        maxPositions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        if(setAtStart)
            SetPosition(margin, side, maxPositions);
    }

    public void SetPosition(float sideMargin, Side setterSide, Vector2 mPos)
    {
        side = setterSide;
        margin = sideMargin;
        switch (side)
        {
            case Side.Top:
                transform.position = new Vector2(transform.position.x, mPos.y + sideMargin);
                break;
            case Side.Bottom:
                transform.position = new Vector2(transform.position.x, -mPos.y + sideMargin);
                break;
            case Side.Right:
                transform.position = new Vector2(mPos.x + sideMargin, transform.position.y);
                break;
            case Side.Left:
                transform.position = new Vector2(-mPos.x + sideMargin, transform.position.y);
                break;
            default:
                transform.position = Vector3.zero;
                break;
        }
    }
}
