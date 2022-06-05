using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    private Lose _lose;
    protected virtual void Awake()
    {
        
    }

    private void Start()
    {
        _lose = (Lose)FindObjectOfType(typeof(Lose));
    }

    public abstract void Initialization(int myPlatformNumber);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (HasComponent.Check<Player>(collision.gameObject))
        {
            Debug.Log("Defeat: " + gameObject);
            //�������� ��������� ��������� ������������ ������ � ����� (� ����� �\��� ��� ������ ����� �����������)
            _lose.Defeat(true);
        }
    }
}
