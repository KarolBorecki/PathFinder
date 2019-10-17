﻿using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SideGenerator : MonoBehaviour
{
    public Transform elementsParent;
    public Vector2 distance;
    public List<Transform> elements;

    private Transform _lastElement;
    private float _randomDistance;

    private bool _isGenerating;

    private int _countingToDestroyObstacles = 0;
    private void Start() {
        _randomDistance = Random.Range(distance.x, distance.y);
    }

    public void StartGenerating()
    {
        for (int i = 0; i < elementsParent.childCount; i++)
            Destroy(elementsParent.GetChild(i).gameObject);
        
        Generate(true);
        _isGenerating = true;
    }

    public void StopGenerating()
    {
        _isGenerating = false;
    }
    private void Update()
    {
        if (!_isGenerating) return;
        if (transform.position.y - _randomDistance >= _lastElement.position.y)
            Generate(false);
        
    }

    private void Generate(bool first)
    {
        int side = Random.Range(0, 2) == 1 ? 1 : -1;
        Transform e = Instantiate(GetRandomFromList(elements), elementsParent);
        e.GetComponent<SideElement>().side = side == 1 ? Responsivity.Side.Right : Responsivity.Side.Left;
        e.position = new Vector3(0, transform.position.y, 0);
        if(!first) {
            e.GetComponent<SideElement>().objReference = _lastElement.gameObject.GetComponent<SideElement>();
            e.GetComponent<SideElement>().OnNewCreate();
        }
        
        _lastElement = e;
        _randomDistance = Random.Range(distance.x, distance.y);
    }
    
    private Transform GetRandomFromList(List<Transform> list)
    {
        return list[Random.Range(0, list.Count)];
    }
    
}