using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Player))]
public class PlayerInput : MonoPausable
{
    public Player _player { get; private set; }
    public event Action SingleTap;
    public event Action DoubleTap;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    //Нужно для проверки на пк, удалить (закоментировать) при сборке для андроида
    public void ActivateSingleTap()
    {
        SingleTap?.Invoke();
    }
    //Нужно для проверки на пк, удалить (закоментировать) при сборке для андроида
    public void ActivateDoubleTap()
    {
        DoubleTap?.Invoke();
    }

    void Update()
    {
        if (_player.transform.parent != null)
        {
            if (Input.touchCount <= 0)
            {
                return;
            }
            foreach (Touch touch in Input.touches)
            {
                if (touch.tapCount == 1 && _pause == false && !EventSystem.current.IsPointerOverGameObject())
                {
                    SingleTap?.Invoke();
                }
                if (touch.tapCount == 2 && _pause == false && !EventSystem.current.IsPointerOverGameObject())
                {
                    DoubleTap?.Invoke();
                }
            }
        }
    }
}
