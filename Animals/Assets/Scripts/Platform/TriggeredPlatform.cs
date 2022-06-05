using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggeredPlatform : MonoBehaviour
{
    public JumpPlayer JumpPlayer { get; private set; }

    private bool CorrectCollision;// { get; private set; }
    public Player Player { get; private set; }
    /// <summary>
    /// ���� ������� ��������� �������� ������ � �������� ���������
    /// </summary>
    private float _onePrecent;
    private float _halfOfPlayerBoxColliderSize;

    //�������� ���������
    public int ExtensionNumber { get; private set; }
    public TriggeredPlatform(int extensionNumber)
    {
        ExtensionNumber = extensionNumber;
    }
    protected virtual void Awake()
    {
        Player = (Player)FindObjectOfType(typeof(Player));
        JumpPlayer = Player.GetComponent<JumpPlayer>();//(JumpPlayer)FindObjectOfType(typeof(JumpPlayer));
    }
    void Start()
    {
        InitSomeVariables();
    }
    
    /// <summary>
    /// �������������� _halfOfPlayerBoxColliderSize � _onePrecent
    /// </summary>
    private void InitSomeVariables()
    {
        BoxCollider2D PlayerBoxCollider = Player.GetComponent<BoxCollider2D>();
        BoxCollider2D _boxCollider = GetComponent<BoxCollider2D>();
        _halfOfPlayerBoxColliderSize = PlayerBoxCollider.size.x / 2;
        _onePrecent = (_boxCollider.size.x / 2 + (_halfOfPlayerBoxColliderSize) * PlayerBoxCollider.transform.localScale.x) / 100;
    }

    public void SetExtensionNumber(int newNumber)
    {
        ExtensionNumber = newNumber;
    }

    public void ScoreCalculatingAndUpadating(float distance)
    {
        Player.ChangeScore(10 - Mathf.RoundToInt(distance / _onePrecent / 10));
    }
    protected abstract void OnCollisionAction();
    protected abstract void OnCollisionExitAction();

    public virtual T NonInheritedData<T>()
    {
        return default(T);
    }

    public virtual void InitializationAfterLoad(float nothing)
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float distancePlayerPlatformCenter;
        if (Vector3.Angle(collision.contacts[0].normal, -Vector3.up) <= 30)
        {
            OnCollisionAction();
            collision.collider.transform.SetParent(transform);
            JumpPlayer.Landing();
            if (ExtensionNumber != 0 && ExtensionNumber > Player.PlatformsPassed - 1)
            {
                distancePlayerPlatformCenter = transform.position.x - collision.collider.transform.position.x;
                ScoreCalculatingAndUpadating(Mathf.Abs(distancePlayerPlatformCenter));
            }
            Player.IncresePlatformsPassed();
            //SetCorrectCollision(true);
            CorrectCollision = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (CorrectCollision)
        {
            collision.collider.transform.SetParent(null);
            //����� �������� ���� ��������� ������ ���������, ���� ��������� ������� ��������� ��������� health
            TryRemove();
            OnCollisionExitAction();
            Player.�hangeStandingOn(PlatformTypes.AIR);
        }
    }

    //����� �������� ����� �� ������� ��� ��������
    private void TryRemove()
    {
        gameObject.SetActive(false);
    }
}
