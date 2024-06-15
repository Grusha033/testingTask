using UnityEngine;

public class animationsIK : MonoBehaviour
{
    private Animator _anim => GetComponent<Animator>();
    private Transform _aimPoint => GameObject.FindGameObjectWithTag("head point").GetComponent<Transform>();
    private Transform _cameraPoint => GameObject.FindGameObjectWithTag("camera point").GetComponent<Transform>();
    private float _raycastDistance = 10.0f;

    public void AnimatorParametersUpdate(float horizontal, float vertical)
    {
        _anim.SetFloat("horizontal", horizontal, 0.1f, Time.deltaTime);
        _anim.SetFloat("vertical", vertical, 0.1f, Time.deltaTime);
    }

    public void IKHeadPointPosUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _raycastDistance, LayerMask.GetMask("")))
        {
            _aimPoint.position = hit.point;
        }
        else
        {
            _aimPoint.position = transform.position + transform.forward * _raycastDistance;
        }

        transform.position = _cameraPoint.position;
    }
}