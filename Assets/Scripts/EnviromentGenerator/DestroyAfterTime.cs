using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTime;
    public Transform destroyEffect;
    
    private void Start()
    {
        Invoke("DestroyItSelf", destroyTime);
    }

    public void DestroyItSelf()
    {
        Transform ps = Instantiate(destroyEffect, transform);
        ps.parent = gameObject.transform.parent;
        Destroy(gameObject);
    }
}
