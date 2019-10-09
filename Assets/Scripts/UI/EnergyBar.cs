using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EnergyBar : MonoBehaviour
{
    public Player player;
    public Vector2 margins;

    public LineRenderer background;

    public SpriteRenderer damageEffect;

    private LineRenderer _energyBarLine;
    private float _barX;
    private float _barY;

    private float _barAmountPerEnergy;

    private void Start()
    {
        _energyBarLine = GetComponent<LineRenderer>();
        
        Vector2 maxPositions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        _barX = maxPositions.x - margins.x;
        _barY = maxPositions.y - margins.y;
        
        _energyBarLine.SetPosition(0, new Vector3(_barX, _barY));
        _energyBarLine.SetPosition(1, new Vector3(-_barX, _barY));
        
        background.SetPosition(0, _energyBarLine.GetPosition(0));
        background.SetPosition(1, _energyBarLine.GetPosition(1));

        _barAmountPerEnergy = _barX * 2 / player.energy;
    }

    private void Update()
    {
        float barDesiredY = transform.parent.position.y + _barY;
        float barDesiredX = player.energy / 2 * _barAmountPerEnergy;
        _energyBarLine.SetPosition(0, new Vector3(barDesiredX, barDesiredY));
        _energyBarLine.SetPosition(1, new Vector3(-barDesiredX, barDesiredY));
        if(!player.shield)
            SetDamageViniette();
        else
            damageEffect.gameObject.SetActive(false);
    }

    private void SetDamageViniette()
    {
        damageEffect.gameObject.SetActive(true);
        SetColorOfDamageViniette(new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b,  
            1f - (float)player.energy / player.maxEnergy));
    }

    private void SetColorOfDamageViniette(Color color)
    {
        damageEffect.color = color;
    }
}