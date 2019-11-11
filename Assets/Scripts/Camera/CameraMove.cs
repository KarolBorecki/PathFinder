using System;
using System.Resources;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameController gameController;
    public Transform player;
    public float smoothSpeed = 0.125f;

    public Vector3 cameraOffset;

    public float cameraSpeed = 2f;
    public float speedingUp = .05f;

    private float _actualSpeed;
    private float _heightSpeed;

    private void Start()
    {
        cameraOffset.z = transform.position.z;
        Reset();
    }

    private void Update()
    {
        if(!gameController.isPlaying) return;
        _heightSpeed = 1;
        transform.Translate(0, _actualSpeed*Time.deltaTime, 0);
        _actualSpeed += speedingUp * Time.deltaTime * _heightSpeed;
    }

    private void FixedUpdate()
    {
        if (!gameController.isPlaying) return;
        Vector3 desiredPosition = player.position + cameraOffset;
        desiredPosition.x = cameraOffset.x;
        if(desiredPosition.y>transform.position.y)
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        _actualSpeed = cameraSpeed;
    }
}
