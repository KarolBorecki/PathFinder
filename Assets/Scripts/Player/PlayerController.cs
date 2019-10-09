using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveForce = 1f;

    private Vector2 _start;
    private Vector2 _end;

    private Rigidbody2D _rgb;
    private CameraBehaviourHandler _cameraBehaviourHandler;
    
    private void Start()
    {
        _rgb = GetComponent<Rigidbody2D>();
        _cameraBehaviourHandler = Camera.main.gameObject.GetComponent<CameraBehaviourHandler>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _start = PlayerAim.GetMousePos();
            _cameraBehaviourHandler.colorDistortion = true;
        }
        if (!Input.GetMouseButtonUp(0)) return;
        _cameraBehaviourHandler.colorDistortion = false;

        _end = PlayerAim.GetMousePos();
        
        _rgb.AddForce(moveForce * (_start - _end));
        _rgb.velocity = Vector2.zero;
    }

}