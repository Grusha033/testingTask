using UnityEngine;

public class CameraController : animationsIK
{
    [SerializeField] private float _sensetivity = 70f; 
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _cameraAngleConstraint = 90f;
    private float _mouseX;
    private float _mouseY;
    private float _xRotation;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        MouseInput();
        RotateCamera();
        IKHeadPointPosUpdate();
    }

    private void MouseInput()
    {
        _mouseX = Input.GetAxis("Mouse X") * _sensetivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _sensetivity * Time.deltaTime;  
    }

    private void RotateCamera()
    {
        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -_cameraAngleConstraint, _cameraAngleConstraint);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * _mouseX); 
    }
}
