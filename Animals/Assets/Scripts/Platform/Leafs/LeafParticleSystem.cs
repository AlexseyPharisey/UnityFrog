using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafParticleSystem : MonoBehaviour
{
    public bool Free { get; private set; }
    public ParticleSystem ParticleSystem { get; private set; }
    private float _lifeTime;
    [SerializeField]
    private PoolerLeafParticleSystem _poolerLeafParticleSystem;
    private void Awake()
    {
        Free = true;
        ParticleSystem = GetComponent<ParticleSystem>();
        _poolerLeafParticleSystem.AddToPool(this);
    }
    private void Start()
    {
        _lifeTime = Mathf.Ceil(ParticleSystem.main.startLifetime.constant);
        gameObject.SetActive(false);
    }
    public void StartUsing()
    {
        Free = false;
        gameObject.SetActive(true);
        ParticleSystem.Play();
        StartCoroutine(EndUsing());
    }
    IEnumerator EndUsing()
    {
        yield return new WaitForSeconds(_lifeTime);
        Free = true;
        gameObject.SetActive(false);
    }
}
