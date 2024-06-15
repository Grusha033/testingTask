using UnityEngine;

public class PlayerController : MonoBehaviour
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
    private AnimationsIK _animationsIK;
    private Vector3 _velocity;
    
    private void Start() 
    {
        _controller = GetComponent<CharacterController>();
        _animationsIK = GetComponent<AnimationsIK>();
    }

    private void Update() 
    {
        KeyInput();
        PlayerMove();
        CustomPhysics();

        _animationsIK.AnimatorParametersUpdate(_horizontal, _vertical);
    }

    private void KeyInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump")) Jump();
    }

    private void PlayerMove()
    {
        Vector3 move = transform.right * _horizontal + transform.forward * _vertical;
        if (move.magnitude > 1) move.Normalize();
        _controller.Move(move * _speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            _velocity.y = Mathf.Sqrt(-_jumpHeight * _playerGravity);
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
