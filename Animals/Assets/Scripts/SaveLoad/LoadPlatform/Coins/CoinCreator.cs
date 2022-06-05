using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreator : MonoBehaviour
{

    [SerializeField] private GameObject NewCoin;

    private Player _player;
    private LevelSettings _levelSettings;
    private LevelData _levelData;
    private Transform _ñoinContainer;

    private CoinMain _temporaryCoinMain;
    private GameObject _temporaryCoinContainer;
    private Vector3 _union = new Vector3(0f, 0f, 0f);

    private void Awake()
    {
        CoinContainer ñoinContainer = (CoinContainer)FindObjectOfType(typeof(CoinContainer));
        _player = (Player)FindObjectOfType(typeof(Player));
        _levelSettings = (LevelSettings)FindObjectOfType(typeof(LevelSettings));
        _levelData = (LevelData)FindObjectOfType(typeof(LevelData));
        _ñoinContainer = ñoinContainer.transform;
    }

    public void Create(int platformNumber)
    {
        _temporaryCoinContainer = Instantiate(NewCoin);
        _temporaryCoinContainer.transform.SetParent(_ñoinContainer, false);
        _temporaryCoinMain = _temporaryCoinContainer.transform.GetChild(0).GetComponent<CoinMain>();

        Vector3 coinPosition = new Vector3(
            Random.Range(GeneratorConst.PLATFORM_X_BORDER * -1, GeneratorConst.PLATFORM_X_BORDER),
            _player.GetComponent<BoxCollider2D>().size.y * _player.transform.localScale.y /2 + _levelSettings.DistanceBetweenPlatforms() * platformNumber + _levelSettings.FirstPlatformOffset(),
            0);
        _temporaryCoinContainer.transform.position = coinPosition;

        _temporaryCoinMain.CoinInit(true,
            Random.Range(1, 100) < _levelData.RichCoinChance ? true : false,
            _levelData.AdditionalCoins,
            false
            );
    }

    public void CreateNew(CoinData coinData)
    {
        _temporaryCoinContainer = Instantiate(NewCoin);
        _temporaryCoinContainer.transform.SetParent(_ñoinContainer, false);
        _temporaryCoinMain = _temporaryCoinContainer.transform.GetChild(0).GetComponent<CoinMain>();

        /*
        _temporaryCoin = Instantiate(NewCoin);
        _temporaryCoinContainer = Instantiate(NewCoinContainer);
        _temporaryCoin.transform.SetParent(_temporaryCoinContainer.transform, false);
        _temporaryCoinContainer.transform.SetParent(_coinPool, false);*/

        _union.x = coinData.Position[0];
        //Debug.Log("x " + Union.x);
        _union.y = coinData.Position[1];
        //Debug.Log("y " + Union.y);
        _union.z = coinData.Position[2];

        _temporaryCoinContainer.transform.position = _union;
        _temporaryCoinMain.CoinInit(true, coinData.RichOrNot, coinData.MinimumCoinInside, false);
    }

    public CoinMain CreateNew(CoinData coinData, bool main, bool free)
    {
        _temporaryCoinContainer = Instantiate(NewCoin);
        _temporaryCoinContainer.transform.SetParent(_ñoinContainer, false);
        _temporaryCoinMain = _temporaryCoinContainer.transform.GetChild(0).GetComponent<CoinMain>();
        //_movingEntity = _temporaryCoinMain.GetComponent<MovingEntity>();
        Animator animator = _temporaryCoinMain.GetComponent<Animator>();

        if (main == false)
            animator.SetBool("Fly", true);            

        _union.x = coinData.Position[0];
        _union.y = coinData.Position[1];
        _union.z = coinData.Position[2];

        _temporaryCoinContainer.transform.position = _union;
        _temporaryCoinMain.CoinInit(main, coinData.RichOrNot, coinData.MinimumCoinInside, free);

        return _temporaryCoinMain;
    }

    public void RecreateCoins(List<CoinData> coinDatas)
    {
        foreach (CoinData coinData in coinDatas)
        {
            CreateNew(coinData);
        }
    }
}
