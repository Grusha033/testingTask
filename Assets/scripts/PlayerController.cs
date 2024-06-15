using UnityEngine;

public class PlayerController : animationsIK
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpHeight = 1f;
    [Space]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [Space]
    [SerializeField] private float _playerGravity = -9.81f;
    private float _horizontal;
    private float _vertical;
    private CharacterController _controller;
    private Vector3 _velocity;
    
    private void Start() 
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update() 
    {
        KeyInput();
        PlayerMove();
        CustomPhysics();
        AnimatorParametersUpdate(_horizontal, _vertical);
    }

    private void KeyInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded()) Jump();
    }

    private void PlayerMove()
    {
        Vector3 move = transform.right * _horizontal + transform.forward * _vertical;
        _controller.Move(move * _speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _playerGravity);
        }
    }

    private void CustomPhysics()
    {
        _velocity.y += _playerGravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private bool isGrounded() 
    {
        return Physics.CheckSphere(_groundCheck.position, 0.2f , _groundMask);
    }
}