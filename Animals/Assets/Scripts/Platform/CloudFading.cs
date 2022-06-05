using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFading : MonoPausable
{
    private Color _color;
    private SpriteRenderer _spriteRenderer;
    private float _fadeSpeed;
    private Player _player;
    private void Awake()
    {
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void SetFadeSpeed(float fadeSpeed)
    {
        _fadeSpeed = fadeSpeed;
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }
    void Update()
    {
        if (_pause == false)
        {
            _color = _spriteRenderer.color;
            _color.a = _spriteRenderer.color.a - Time.deltaTime * _fadeSpeed;
            _spriteRenderer.color = _color;
            if (_spriteRenderer.color.a <= 0.05f)
            {
                _player.transform.SetParent(null);//�������� ��� ������ ����������� ����������� ������������� player ��������� ��� � � base platform
                gameObject.SetActive(false);
                _player.GetComponent<Lose>().Checking(); //��� ��� �������� lose ����� ���� ������������� �� ������ LoseUser ������� ���������� ������ ����� LoseCheck � �������� ��� ������������� ����� ����� ��� � ������ ��������������� ������
            }
        }
    }
}
