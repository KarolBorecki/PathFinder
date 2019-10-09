using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    public Vector2 maxXPosition;
    public Vector2 elementsMargin;
    public List<Transform> environmentElements;
    public Transform elementsParent;

    private float _lastOne;
    private float _actualMargin;

    private void Start()
    {
    }

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
        Transform e = Instantiate(GetRandomFromList(environmentElements), elementsParent);
        e.position = new Vector3(Random.Range(maxXPosition.x, maxXPosition.y), transform.position.y + elementsMargin.y,
            0);
        _lastOne = e.position.y;
        _actualMargin = Random.Range(elementsMargin.x, elementsMargin.y);
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