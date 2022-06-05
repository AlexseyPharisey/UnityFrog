using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolerLeafParticleSystem : MonoBehaviour
{
    public List<LeafParticleSystem> _pool;

    public void AddToPool(LeafParticleSystem leafParticle)
    {
        _pool.Add(leafParticle);
    }

    public LeafParticleSystem TryFindFreeParticleSystem()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i].Free)
            {
                return _pool[i];
            }
        }
        return null;
    }
}
