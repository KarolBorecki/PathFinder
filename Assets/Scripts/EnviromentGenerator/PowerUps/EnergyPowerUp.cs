using UnityEngine;

public class EnergyPowerUp : PowerUp
{
    public void OnTriggerEnter2D(Collider2D collision){
      Debug.Log("AWF");
        if(!collision.gameObject.CompareTag("Player")) return;
        base.OnPickUp();
        collision.gameObject.GetComponent<Player>().AddEnergy(number);
    }
}
