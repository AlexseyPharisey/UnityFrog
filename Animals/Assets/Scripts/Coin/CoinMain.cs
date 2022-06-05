using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(TriggeredCoin))]
public class CoinMain : Entity
{
    private IMovingEntity _movingEntity;
    [SerializeField] private Transform _containerTransform;
    [SerializeField] private bool _main;
    private Animator _animator;
    public bool Rich; //{ get; private set; }
    public int AdditionalCoins; //{ get; private set; }
    //public int MaxAdditionalCoins; //{ get; private set; }
    public bool Main { get => _main; set => _main = value; }
    public bool FreeState; // { get; private set; }

    public void CoinInit(bool main, bool rich, int minAdditionalCoins, bool freeState)
    {
        _main = main;
        Rich = rich;
        AdditionalCoins = minAdditionalCoins;
        //MaxAdditionalCoins = maxAdditionalCoins;
        FreeState = freeState;
    }

    private void Awake()
    {
        _movingEntity = _containerTransform.GetComponent<IMovingEntity>();
    }
    private new void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
    }

    public void SetAnimationState(string state, bool value)
    {
        _animator.SetBool(state, value);
    }

    public void AnimatorSwitch(bool value)
    {
        _animator.enabled = value;
    }

    public void SetContainerPosition(Vector3 position)
    {
        _containerTransform.position = position;
    }

    public Transform GetContainerTransform()
    {
        return _containerTransform;
    }

    public void NewMovement(Vector3 pointToMove, float lerpPrecent)
    {
        _movingEntity.SetActive(true);
        _movingEntity.SetMoveTo(pointToMove, lerpPrecent);
    }

    public void NewMovement(ITarget target, IEasing easing)
    {
        _movingEntity.SetActive(true);
        _movingEntity.SetMoveTo(target, easing);
    }

    public void NewMovement(Vector3 pointToMove, IEasing easing)
    {
        _movingEntity.SetActive(true);
        _movingEntity.SetMoveTo(pointToMove, easing);
    }

    public void StopMove()
    {
        _movingEntity.SetActive(false);
    }

    public void FreeingCoin()
    {
        FreeState = true;
    }

    public void DoNotFreeCoin()
    {
        FreeState = false;
    }

    protected override void StorageInit()
    {
        PoolCoin pool = PoolCoin.Instance;
        _storage = pool.GetStorage();
    }
}
