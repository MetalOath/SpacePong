using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerOneScore = 0;
    public int playerTwoScore = 0;

    [SerializeField]
    private GameObject _playerOne, _playerTwo, _ball, _centerLine, _startGameButton, _gameEndText, _playAgainButton;

    [SerializeField]
    private TextMeshProUGUI _playerOneScore, _playerTwoScore;

    private void Awake()
    {
        _playerOne.SetActive(false);
        _playerTwo.SetActive(false);
        _ball.SetActive(false);
        _centerLine.SetActive(false);
        _gameEndText.SetActive(false);
        _playAgainButton.SetActive(false);
        _startGameButton.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EndGame()
    {
        _playerOne.SetActive(false);
        _playerTwo.SetActive(false);
        _ball.SetActive(false);
        _centerLine.SetActive(false);
        _gameEndText.SetActive(true);
        _playAgainButton.SetActive(true);
    }

    public void StartGame()
    {
        _playerOne.SetActive(true);
        _playerTwo.SetActive(true);
        _ball.SetActive(true);
        _centerLine.SetActive(true);
        _startGameButton.SetActive(false);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Main");
    }
}
