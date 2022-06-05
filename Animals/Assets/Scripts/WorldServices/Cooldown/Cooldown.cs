using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Cooldown : ScriptableEntity
{
    private ICooldownable _cooldownable;
    private float _endTime;// { get; private set; }
    private float _readinessTimer;// { get; private set; }

    public Cooldown(ICooldownable cooldownable, float endTime)
    {
        _cooldownable = cooldownable;
        _endTime = endTime;
    }
    protected override void StorageInit()
    {
        CooldownExecutor cooldownExecutor = CooldownExecutor.Instance;//(CooldownExecutor)UnityEngine.Object.FindObjectOfType(typeof(CooldownExecutor));
        _storage = cooldownExecutor.GetStorage();
    }

    public void Update()
    {
        _readinessTimer += Time.deltaTime;
        if (_readinessTimer >= _endTime)
        {
            _cooldownable.CooldownEnd();
            Destroy(this);
        }
    }
}
