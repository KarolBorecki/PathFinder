using UnityEngine;

[RequireComponent(typeof(Responsivity))]
public class SideElement : MonoBehaviour
{
    public Responsivity.Side side;
    public float scale;

    public SideElement objReference;

    public int index;

    void Start()
    {
        float width = 5 * Screen.width / Screen.height;
        transform.eulerAngles = new Vector3(0, side == Responsivity.Side.Right ? 0 : 180, 0);
        transform.localScale = new Vector3(width * scale, width * scale, width * scale);
        //gameObject.GetComponent<Responsivity>().SetPosition(0, side, GameObject.FindGameObjectWithTag("Boundry").GetComponent<Responsivity>().maxPositions);
    }

    public void OnNewCreate()
    {
        index++;
        if (index <= 5)
        {
            if (objReference != null)
                objReference.OnNewCreate();
        }
        else
            Destroy(gameObject);
    }
}
