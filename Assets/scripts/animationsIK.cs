using UnityEngine;

public class AnimationsIK : MonoBehaviour
{
    private Animator _anim;
    private Transform _aimPoint;
    private float _raycastDistance = 10.0f;
    private Transform _camPos;

    private void Start() 
    {
        _anim = GetComponent<Animator>();
        _aimPoint = GameObject.FindGameObjectWithTag("head point").GetComponent<Transform>();
        _camPos = Camera.main.GetComponent<Transform>();
    }

    public void AnimatorParametersUpdate(float horizontal, float vertical)
    {
        _anim.SetFloat("horizontal", horizontal, 0.1f, Time.deltaTime);
        _anim.SetFloat("vertical", vertical, 0.1f, Time.deltaTime);
    }

    public void IKHeadPointPosUpdate()
    {
        Ray ray = new Ray(_camPos.position, _camPos.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _raycastDistance, LayerMask.GetMask("")))
        {
            _aimPoint.position = hit.point;
        }
        else
        {
            _aimPoint.position = _camPos.position + _camPos.forward * _raycastDistance;
        }
    }
}