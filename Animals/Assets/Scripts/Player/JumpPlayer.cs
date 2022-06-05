using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]
public class JumpPlayer : MonoBehaviour
{
    public bool InJump { get; private set; }
    private bool _moveUpDown;
    private bool loseState;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Player _player;
    private Lose _lose;

    private float _timeInFlightUp;
    private float _timeInJump;
    /// <summary>
    /// Смещение высоты первой платформы (на которой стартует игрок) относительно начала координат.
    /// </summary>
    private float _hightOffset;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _hightOffset = transform.position.y;
        _player = GetComponent<Player>();
        _lose = (Lose)FindObjectOfType(typeof(Lose));

        FindObjectOfType<PlayerInput>().SingleTap += Jump;
        FindObjectOfType<PlayerInput>().DoubleTap += JumpFromSwamp;
        _lose.defeat += WeLose;
    }
    void Start()
    {
        _timeInFlightUp = (2 * LevelSettings.singleton.JumpStrenght()) / (_rigidbody2D.gravityScale * 20);
    }

    private void WeLose()
    {
        FindObjectOfType<PlayerInput>().SingleTap -= Jump;
        FindObjectOfType<PlayerInput>().DoubleTap -= JumpFromSwamp;
        _lose.defeat -= WeLose;
        loseState = true;
    }
    //заметка: обьедеинить Jump и jumpfromswamp и передавать с параметром тап или дабл тап или прыжок с батута
    //Или нет. Ипут просто передает тап или дабл тап. jump уже обрабатывает какой это должен быть jump, и наконец что то третье совершает сам jump
    //В любом случае это надо переделать
    private void Jump()
    {
        if (_player.StandingOn != PlatformTypes.SWAMP)
        {
            if (_player.StandingOn != PlatformTypes.TRAMPOLINE)
            {
                StartMoveUp();
            }
            else
            {
                StartMoveUp(LevelSettings.singleton.TrampolineAddedJumpStrenght());
            }
        }
        else
        {
            //проигрываем анимацию неудачного выпрыгивания из болота
        }
    }
    private void JumpFromSwamp()
    {
        StartMoveUp();
    }
    private void StartMoveUp()
    {
        _rigidbody2D.velocity = new Vector3(0, LevelSettings.singleton.JumpStrenght(), 0);
        InJump = true;
        _moveUpDown = true;
        _spriteRenderer.sortingOrder = 0;
        _animator.SetBool("JumpUp", true);
    }

    private void StartMoveUp(float addedJumpStrenght)
    {
        _rigidbody2D.velocity = new Vector3(0, LevelSettings.singleton.JumpStrenght() + addedJumpStrenght, 0);
        InJump = true;
        _moveUpDown = true;
        _spriteRenderer.sortingOrder = 0;
        _animator.SetBool("JumpUp", true);
    }
    private void MovingUp() 
    {
        _timeInJump = _timeInJump + Time.fixedDeltaTime;
        if (_timeInJump > _timeInFlightUp)
        {
            _timeInJump = 0.0f;
            _moveUpDown = false;
            StartFalling();
        }
    }

    private void StartFalling()
    {
        _spriteRenderer.sortingOrder = -2;
        _animator.SetBool("JumpUp", false);
        _animator.SetBool("JumpDown", true);
    }
    private void Falling()
    {
        if (transform.position.y <= (LevelSettings.singleton.DistanceBetweenPlatforms() * _player.PlatformsPassed) - 0.1f + _hightOffset)
        {
            //Debug.Log("Проверка");
            if(loseState == false)
                _lose.Checking();
        }
    }

    public void Landing()
    {
        InJump = false;
        _moveUpDown = false;
        _animator.SetBool("JumpUp", false);
        _animator.SetBool("JumpDown", false);
    }

    private void FixedUpdate()
    {
        if (InJump)
        {
            if (_moveUpDown)
            {
                MovingUp();
            }
            else
            {
                Falling();
            }
        }
    }
}
