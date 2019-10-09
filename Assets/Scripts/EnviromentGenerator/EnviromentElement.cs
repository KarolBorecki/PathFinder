using UnityEngine;

public class EnviromentElement : MonoBehaviour
{
    public EnviromentElement objReference;

    public void OnNewCreate(EnviromentElement e = null)
    {
        if(e!=null)
            objReference = e;
        if(objReference != null)
            objReference.OnNewCreate();
        else
            Destroy(gameObject);
    }
}
