﻿using UnityEngine;

[RequireComponent(typeof(Responsivity))]
public class SideElement : MonoBehaviour
{
    public Responsivity.Side side;
    public float scale;

    public SideElement objReference;

    public int index;

    void Start()
    {
        float width = Camera.main.orthographicSize * Screen.width / Screen.height;
        transform.eulerAngles = new Vector3(0, side == Responsivity.Side.Right ? 0 : 180, 0);
        transform.localScale = new Vector3(width * scale, width * scale, width * scale);
        gameObject.GetComponent<Responsivity>().SetPosition(0, side);
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