using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLeafParticleSystem : MonoBehaviour
{
    private PoolerLeafParticleSystem _leafParticleSystemPooler;
    private LeafParticleSystem _particleSystem;
    private void Awake()
    {
        _leafParticleSystemPooler = GetComponent<PoolerLeafParticleSystem>();
    }
    public LeafParticleSystem PlaceAtPoint(Vector3 targetPoint)
    {
        _particleSystem = _leafParticleSystemPooler.TryFindFreeParticleSystem();
        if (_particleSystem != null)
        {
            _particleSystem.transform.position = targetPoint;
            //_particleSystem.StartUsing();
            return _particleSystem;
        }
        else
        {
            Debug.Log("нет свободных leafParticleSystem");
            return null;
        }            
    }
}
