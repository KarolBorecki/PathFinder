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

    private float actualSpeed;

    private void Start()
    {
        cameraOffset.z = transform.position.z;
        Reset();
    }

    private void Update()
    {
        if(!gameController.isPlaying) return;
        transform.Translate(0, actualSpeed*Time.deltaTime, 0);
        actualSpeed += speedingUp * Time.deltaTime;
        Debug.Log(actualSpeed);
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
        actualSpeed = cameraSpeed;
    }
}
