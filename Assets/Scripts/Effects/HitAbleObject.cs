using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitAbleObject : MonoBehaviour
{
    public ParticleSystem particleEffect;
    public Color color;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        ParticleSystem ps = Instantiate(particleEffect, transform);
        ps.transform.position = other.contacts[0].point;
        ps.startColor = color;
        
    }
}
