using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlayerAim : MonoBehaviour
{
    public float timeSlowDown = 0.05f;
    public float aimLength;

    public float slowDownEnergyDecrease = 2.5f;

    private Player _player;

    private LineRenderer _line;
    private Vector2 _mouseOnClickPos;

    private Vector2 _endPos;
    private Vector2 _playerOnClickPos;

    private void Start()
    {
        _player = gameObject.GetComponent<Player>();
        _line = gameObject.GetComponent<LineRenderer>();
    }

    private void Update()
    {
      if(!_player.isInGame) return;
        if (Input.GetMouseButtonDown(0))
        {
            SlowTimeDown();
            _mouseOnClickPos = GetMousePos();
            _playerOnClickPos = transform.position;
        }
        if (Input.GetMouseButton(0))
        {
            _endPos = _mouseOnClickPos - GetMousePos();
            _endPos.y += transform.position.y - _playerOnClickPos.y;

//            _endPos = new Vector2(_endPos.x + aimLength* ((1 / Mathf.Abs(_endPos.x))*_endPos.x),
//                _endPos.y + aimLength* ((1 / Mathf.Abs(_endPos.y))*_endPos.y));

            _line.positionCount = 2;
            _line.SetPosition(0, Vector3.zero);
            _line.SetPosition(1, _endPos);

            _player.DecreaseEnergy(slowDownEnergyDecrease);
        }
        else
        {
            _line.positionCount = 0;
            Time.timeScale = 1;
        }
    }

    public static Vector2 GetMousePos()
    {
        return Camera.main == null ? Vector3.forward : Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void SlowTimeDown()
    {
        Time.timeScale = timeSlowDown;
        Time.fixedDeltaTime = Time.timeScale * timeSlowDown;
    }

    public void ClearLine()
    {
        if(_line != null)
            _line.positionCount = 0;
    }
}
