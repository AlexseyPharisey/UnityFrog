using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private GameObject _endGameMenu;
    [SerializeField] private Text _endGameText;
    private bool CantLose;


    void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (_player.position.y <= _mainCamera.position.y - 6 && CantLose == false)
        {
            _endGameMenu.SetActive(true);
            _endGameText.text = "GameOver";
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _endGameMenu.SetActive(true);
            _endGameText.text = "You Win!!";
            Time.timeScale = 0;
        }
    }

    public void LoseFlagChange()
    {
        CantLose = !CantLose;
    }

    public void EndGameButton()
    {
        SceneManager.LoadScene(0);
    }
}
