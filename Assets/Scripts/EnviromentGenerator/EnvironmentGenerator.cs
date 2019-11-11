using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    public Vector2 maxXPosition;
    public Vector2 elementsMargin;
    public List<PowerUp> environmentElements;
    public Transform elementsParent;

    private float _lastOne;
    private float _actualMargin;

    private void Update()
    {
        if (_lastOne + _actualMargin<= transform.position.y)
            Spawn();
    }

    public void StartGenerating()
    {
        ClearEnvironment();
        Spawn();
    }

    private void Spawn()
    {
      if(!(environmentElements.Count>0)) return;
        PowerUp e = Instantiate(environmentElements[Random.Range(0, environmentElements.Count)], elementsParent);
        e.transform.position = new Vector3(Random.Range(maxXPosition.x, maxXPosition.y), transform.position.y + elementsMargin.y,
            0);
        _lastOne = e.transform.position.y;
        _actualMargin = Random.Range(elementsMargin.x, elementsMargin.y);
    }

    public void AddNewPowerUp(PowerUp powerUp){
        environmentElements.Add(powerUp);
    }

    private void ClearEnvironment()
    {
        for (int i = 0; i < elementsParent.childCount; i++)
            Destroy(elementsParent.GetChild(i).gameObject);
    }

    private Transform GetRandomFromList(List<Transform> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
