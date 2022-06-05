using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private float _smoothSpeed = 12.5f;
    [SerializeField]
    private Vector3 _offset;

    private Vector3 _desPos;
    private Vector3 _smthPos;

    private bool _iFollow;

    private void Awake()
    {
        FindObjectOfType<Lose>().defeat += StopFollowing;
    }
    private void Start()
    {
        _iFollow = true;
    }

    private void StopFollowing()
    {
        _iFollow = false;
        FindObjectOfType<Lose>().defeat -= StopFollowing;
    }
    private void LateUpdate()
    {
        if (_iFollow)
        {
            _desPos = _player.position + _offset;
            _desPos.x = 0;
            _smthPos = Vector3.Lerp(transform.position, _desPos, _smoothSpeed * Time.deltaTime);
            transform.position = _smthPos;
        }
    }
}
