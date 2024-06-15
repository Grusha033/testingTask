using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _sensetivity = 70f; 
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _cameraAngleConstraint = 90f;

    private Transform _cameraPoint;
    private AnimationsIK _animationsIK;
    private float _mouseX;
    private float _mouseY;
    private float _xRotation;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cameraPoint = GameObject.FindGameObjectWithTag("camera point").GetComponent<Transform>();
        _animationsIK = GetComponentInParent<AnimationsIK>();
    }

    private void Update()
    {
        MouseInput();
        RotateCamera();
        _animationsIK.IKHeadPointPosUpdate();

        transform.position = _cameraPoint.position;
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
