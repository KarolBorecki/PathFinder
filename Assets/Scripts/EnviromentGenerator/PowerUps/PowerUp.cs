using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyAfterTime))]
public class PowerUp : MonoBehaviour
{
    public int number;

    public void OnPickUp(){
      gameObject.GetComponent<DestroyAfterTime>().DestroyItSelf();
    }
}
