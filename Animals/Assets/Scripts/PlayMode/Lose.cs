using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider2D))]
public class Lose : MonoBehaviour
{
    public event Action defeat;

    private int _layerMask;

    private BoxCollider2D _playerBoxCollider;

    private Vector3 _leftBorderBoxCollider;
    private Vector3 _rightBorderBoxCollider;

    private void Awake()
    {
        _playerBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        _layerMask = 1 << 8;
        _layerMask = ~_layerMask;
    }

    private void BoxColliderBordersCalculation()
    {
        _leftBorderBoxCollider = transform.position;
        _leftBorderBoxCollider.x = _leftBorderBoxCollider.x - (_playerBoxCollider.size.x / 2) * transform.localScale.x;
        _leftBorderBoxCollider.y = _leftBorderBoxCollider.y + (_playerBoxCollider.size.y / 2) * transform.localScale.y;

        _rightBorderBoxCollider = transform.position;
        _rightBorderBoxCollider.x = _rightBorderBoxCollider.x + (_playerBoxCollider.size.x / 2) * transform.localScale.x;
        _rightBorderBoxCollider.y = _rightBorderBoxCollider.y + (_playerBoxCollider.size.y / 2) * transform.localScale.y;
    }
    public bool RayCastFromLeftRightBorder()
    {
        BoxColliderBordersCalculation();

        Vector3 leftTarget = _leftBorderBoxCollider;
        leftTarget.y = -20f;
        Vector3 rightTarget = _rightBorderBoxCollider;
        rightTarget.y = -20f;

        _playerBoxCollider.enabled = false;

        RaycastHit2D hitRight = Physics2D.Raycast(_rightBorderBoxCollider, rightTarget, Mathf.Infinity, _layerMask);
        Debug.DrawLine(_rightBorderBoxCollider, rightTarget, Color.red, 5f);

        RaycastHit2D hitLeft = Physics2D.Raycast(_leftBorderBoxCollider, leftTarget, Mathf.Infinity, _layerMask);
        Debug.DrawLine(_leftBorderBoxCollider, leftTarget, Color.blue, 5f);

        if (hitLeft.collider.name == "LoseCollider" && hitRight.collider.name == "LoseCollider")
        {
            _playerBoxCollider.enabled = true;
            return true;
        }
        else
        {
            _playerBoxCollider.enabled = true;
            return false;
        }
    }

    public void Defeat(bool deathFromTraps)
    {
        if (deathFromTraps)
        {
            //Fade begins here
            _playerBoxCollider.enabled = false;
            defeat?.Invoke();
        }
        else
        {
            _playerBoxCollider.enabled = false;
            defeat?.Invoke();
        }
    }
    public void Checking()
    {
        if (RayCastFromLeftRightBorder())
        {
            Defeat(false);
        }
        else
        {
            //Debug.Log("Игра продолжается");
        }
    }
}
