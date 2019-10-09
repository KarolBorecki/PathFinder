using Kino;
using UnityEngine;

public class CameraBehaviourHandler : MonoBehaviour
{
    public bool colorDistortion;
    public float colorDistortionSpeed;

    public bool cameraZoom;
    public float cameraZoomSpeed;
    
    private AnalogGlitch _glitch;
    private Camera _camera;

    private void Start()
    {
        _glitch = gameObject.GetComponent<AnalogGlitch>();
        _camera = gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        if (colorDistortion) {
            if(_glitch.colorDrift <= 1)
                _glitch.colorDrift += Time.deltaTime* colorDistortionSpeed;
        }else if(_glitch.colorDrift>= 0)
        {
            _glitch.colorDrift = 0;
        }
        
        if (cameraZoom && _camera.orthographicSize >= 3f) {
            _camera.orthographicSize -= Time.deltaTime* cameraZoomSpeed;
        }else if(_camera.orthographicSize < 5)
        {
            _camera.orthographicSize += Time.deltaTime* cameraZoomSpeed;
        }else if (_camera.orthographicSize > 5) _camera.orthographicSize = 5;
    }

    public void CameraShake()
    {
        GetComponent<Animator>().SetTrigger("Shake");
    }

    public void CameraZoomIn()
    {
        GetComponent<Animator>().SetTrigger("Zoom");
    }
}