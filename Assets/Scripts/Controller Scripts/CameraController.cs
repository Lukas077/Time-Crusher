using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform _target;

    public Vector3 _cameraOffset;
    public float _zoomSpeed = 4f;
    public float _minZoom = 5f;
    public float _maxZoom = 15f;

    public float _pitch = 2f;

    public float _yawSpeed = 100f;

    private float _currentZoom = 10f;
    private float _currentYaw = 0f;

    void Update()
    {
        _currentZoom -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
        _currentZoom = Mathf.Clamp(_currentZoom, _minZoom, _maxZoom);

        _currentYaw -= Input.GetAxis("Horizontal") * _yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = _target.position - _cameraOffset * _currentZoom;
        transform.LookAt(_target.position + Vector3.up * _pitch);

        transform.RotateAround(_target.position, Vector3.up, _currentYaw);
    }
}
