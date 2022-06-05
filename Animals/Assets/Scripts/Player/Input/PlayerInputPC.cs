//Нужно для проверки на пк, удалить (закоментировать) при сборке для андроида. Весь класс.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerInputPC : MonoPausable
{
    public Player _player { get; private set; }
    private PlayerInput _playerInput;

    //Нужно для проверки на пк, удалить при сборке для андроида
    private float doubleClickTimeLimit = 0.15f;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerInput = GetComponent<PlayerInput>();
    }

    //Нужно для проверки на пк, удалить при сборке для андроида
    protected void Start()
    {
        StartCoroutine(InputListener());
    }
    //Нужно для проверки на пк, удалить при сборке для андроида
    private IEnumerator InputListener()
    {
        while (enabled)
        { 
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                yield return ClickEvent();

            yield return null;
        }
    }
    //Нужно для проверки на пк, удалить при сборке для андроида
    private IEnumerator ClickEvent()
    {
        //pause a frame so you don't pick up the same mouse down event.
        yield return new WaitForEndOfFrame();

        float count = 0f;
        while (count < doubleClickTimeLimit)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                DoubleClick();
                yield break;
            }
            count += Time.deltaTime;// increment counter by change in time between frames
            yield return null; // wait for the next frame
        }
        SingleClick();
    }
    //Нужно для проверки на пк, удалить при сборке для андроида
    private void SingleClick()
    {
        if (_player.transform.parent != null && _pause==false)
        {
            _playerInput.ActivateSingleTap();
        }
    }
    //Нужно для проверки на пк, удалить при сборке для андроида
    private void DoubleClick()
    {
        if (_player.transform.parent != null && _pause == false)
        {
            _playerInput.ActivateDoubleTap();
        }
    }
}
