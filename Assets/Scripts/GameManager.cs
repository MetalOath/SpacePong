using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int _playerOneScore = 0;
    private int _playerTwoScore = 0;
    private int _ballDirection = 1;

    [SerializeField]
    private GameObject _playerOne, _playerTwo, _ball, _centerLine, _startGameButton, _playAgainButton;

    [SerializeField]
    private TextMeshProUGUI _playerOneScoreText, _playerTwoScoreText, _gameEndText;

    public int playerOneScore
    {
        get { return _playerOneScore; }
        set
        {
            _playerOneScore = value;

            if (_playerOneScore > 2)
            {
                _playerOneScore = 3;
                _gameEndText.text = "PLAYER ONE WINS!";

                EndGame();
            }
            else
            {
                _ballDirection = 1;

                Instantiate(_ball);
            }

            _playerOneScoreText.text = _playerOneScore.ToString();

            Debug.Log("Player One Score: " + playerOneScore.ToString());
        }
    }

    public int playerTwoScore
    {
        get { return _playerTwoScore; }
        set
        {
            _playerTwoScore = value;

            if (_playerTwoScore > 2)
            {
                _playerTwoScore = 3;
                _gameEndText.text = "PLAYER TWO WINS!";

                EndGame();
            }
            else
            {
                _ballDirection = -1;

                Instantiate(_ball);
            }

            _playerTwoScoreText.text = _playerTwoScore.ToString();

            Debug.Log("Player Two Score: " + _playerTwoScore.ToString());
        }
    }

    public int ballDirection
    {
        get
        {
            return _ballDirection;
        }
    }

    private void Awake()
    {
        _playerOne.SetActive(false);
        _playerTwo.SetActive(false);
        _centerLine.SetActive(false);
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
        _centerLine.SetActive(false);
        _playAgainButton.SetActive(true);
    }

    public void StartGame()
    {
        Instantiate(_ball);
        _playerOne.SetActive(true);
        _playerTwo.SetActive(true);
        _centerLine.SetActive(true);
        _startGameButton.SetActive(false);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Main");
    }
}
