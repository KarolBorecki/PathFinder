using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerAim))]
[RequireComponent(typeof(TrailRenderer))]
public class Player : MonoBehaviour
{
    public GameController gameController;

    public Vector2 startPos;

    public int pointsInGame;
    public TextHandler pointsCounter;

    public int energy = 1500;
    public bool shield;
    public float shieldTime;
    public float shieldCamSlowDown = .5f;

    public float hurtTime = 1;

    public int combo;
    public float timeToLoseCombo = .5f;
    public int maxCombo = 5;
    public int bouncesTillCombo = 3;

    public ParticleSystem comboParticles;
    public TextHandler comboHandler;
    public Transform deadParticle;
    public Transform damageParticle;
    public Transform shieldPrefab;

    public CameraMove camMove;
    
    [HideInInspector]
    public bool isInGame;

    private CameraBehaviourHandler _camera;

    private float _actualShieldTime;
    
    [HideInInspector]
    public int maxEnergy;

    private bool _isHurt;
    private float _actualHurtTime;
    private int _actualBounces;
    private float _actualComboTime;

    public PointsFlyAway pointsEffect;

    private void Start()
    {
        _camera = Camera.main.gameObject.GetComponent<CameraBehaviourHandler>();
        maxEnergy = energy;

        Reset();
    }

    private void Update()
    {
//        int pointsToAdd = (int) transform.position.y * 10 * (combo + 1);
//        if (pointsToAdd > pointsInGame)
//        {
//            pointsInGame = pointsToAdd;
//            pointsCounter.SetText(pointsInGame);
//        }

        if (shield)
            if (_actualShieldTime < shieldTime)
                _actualShieldTime += Time.deltaTime;
            else
                DeactivateShield();

        if (_actualBounces > 0)
        {
            _actualComboTime += Time.deltaTime;// / ((Time.deltaTime < 1) ? GetComponent<PlayerAim>().timeSlowDown : 1);
            if (_actualComboTime >= timeToLoseCombo)
                DecreaseCombo();
        }

        if (!_isHurt) return;

        _actualHurtTime += Time.deltaTime;

        if (_actualHurtTime <= hurtTime) return;

        SetIsHurt(false);
        _actualHurtTime = 0;
    }

    private void Dead()
    {
        isInGame = false;
        Transform p = Instantiate(deadParticle, transform);
        p.parent = null;

        _camera.CameraShake();
        _camera.colorDistortion = false;
        gameController.AddMoney(pointsInGame);
        gameController.GameOver();
    }

    private void TakeDamage(int amount)
    {
        if (shield || _isHurt || !isInGame) return;

        Instantiate(damageParticle, transform);
        _camera.CameraShake();
        _camera.colorDistortion = false;

        DecreaseEnergy(amount);
        SetIsHurt(true);
        ResetCombo();
    }

    public void DecreaseEnergy(int amount)
    {
        energy -= amount;

        if (energy > 0) return;

        energy = 0;
        Dead();
    }

    public void Activate()
    {
        isInGame = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        
        GetComponent<TrailRenderer>().enabled = true;
    }

    public void Reset()
    {
        isInGame = false;

        SetIsHurt(false);
        DeactivateShield();
        
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        
        energy = maxEnergy;
        
        pointsInGame = 0;
        pointsCounter.SetText(pointsInGame);
        
        ResetCombo();

        camMove.Reset();
        
        GetComponent<TrailRenderer>().enabled = false;

        transform.position = startPos;
    }

    private void ActivateShield()
    {
        shield = true;
        shieldPrefab.gameObject.SetActive(true);
        _actualShieldTime = 0;
        camMove.cameraSpeed *= shieldCamSlowDown;
        SetIsHurt(false);
        
        AddPoints(150);
    }

    private void DeactivateShield()
    {
        if (!shield) return;
        shield = false;
        shieldPrefab.gameObject.SetActive(false);
        _actualShieldTime = 0;
        camMove.cameraSpeed /= shieldCamSlowDown;
    }

    private void AddEnergy(int amount)
    {
        energy += amount;
        if (energy > maxEnergy) energy = maxEnergy;
        SetIsHurt(false);
        
        AddPoints(80);
    }

    private void AddCombo()
    {
        if (combo < maxCombo)
        {
            combo++;
            comboHandler.SetTextAsCombo(combo);
        }
        
        Instantiate(comboParticles, transform);

        
        _actualComboTime = 0;
    }

    private void DecreaseCombo()
    {
        if (combo > 0)
        {
            combo--;
            comboHandler.SetTextAsCombo(combo);
        }

        _actualComboTime = 0;
    }

    private void ResetCombo()
    {
        combo = 1;
        _actualBounces = 0;
        _actualComboTime = 0;
        comboHandler.SetTextAsCombo(combo);
    }

    private void SafeBounce()
    {
        AddPoints(50);
        if (_isHurt) return;
        _camera.CameraZoomIn();
        _actualBounces++;
        if (_actualBounces % bouncesTillCombo == 0)
            AddCombo();
    }

    private void SetIsHurt(bool hurt)
    {
        _isHurt = hurt;
        gameObject.GetComponent<Animator>().SetBool("isHurt", hurt);
    }

    private void AddPoints(int amount)
    {
        pointsInGame += amount * (combo + 1);

        PointsFlyAway t = Instantiate(pointsEffect, transform);
        t.SetText("+" + amount * (combo+1));
        pointsCounter.SetText(pointsInGame);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isInGame) return;

        if (other.gameObject.CompareTag("DeadArea"))
            TakeDamage(other.gameObject.GetComponent<DeadArea>().damage);
        else if (other.gameObject.CompareTag("BouncySurface"))
            ActivateShield();
        else if (other.gameObject.CompareTag("Void"))
            Dead();
        else
            SafeBounce();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("EnergyPowerUp")) return;

        AddEnergy(other.gameObject.GetComponent<EnergyPowerUp>().energy);
        other.gameObject.GetComponent<DestroyAfterTime>().DestroyItSelf();
    }

    //public void SetPlayerLook(Sprite newSprite, Color newColor)
    //{
    //    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    //    spriteRenderer.sprite = newSprite;
    //    spriteRenderer.color = newColor;
    //}
}