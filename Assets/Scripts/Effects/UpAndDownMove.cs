using UnityEngine;

public class UpAndDownMove : MonoBehaviour
{
    public float speed = 5f;
    public float range = 10; 
    public bool vertical = true;

    private Vector2 turn;
    private float actualRange;
    public int dir = -1;

    private void Start()
    {
        turn = vertical ? Vector2.right : Vector2.up;
        actualRange = range * dir;
    }

    private void Update()
    {
        if (Mathf.RoundToInt(System.Math.Abs(actualRange)) < range){
            Vector2 r = getTransformingValue();
            gameObject.transform.Translate(r);
            actualRange += speed * dir * Time.deltaTime;
        }
        else
        {
            changeDirection();
        }

    }

    void changeDirection()
    {
        actualRange = Mathf.RoundToInt(range - System.Math.Abs(actualRange));
        dir *= -1;
    }

    private Vector2 getTransformingValue() { return turn * speed * dir * Time.deltaTime; }
}
