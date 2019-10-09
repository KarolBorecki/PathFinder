using UnityEngine;

public class PointsFlyAway : MonoBehaviour
{
    public float flySpeed = 2.0f;
    
    private void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime*flySpeed, 0);
    }

    public void SetText(string txt)
    {
        gameObject.GetComponent<TextMesh>().text = txt;
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
