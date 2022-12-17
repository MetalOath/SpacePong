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
    private GameObject _Obstacle, _SpeedBooster, _SpeedDamper, _Splitter;

    [SerializeField]
    private List<GameObject> _pickupSpawnLocations;

    [SerializeField]
    private TextMeshProUGUI _playerOneScoreText, _playerTwoScoreText, _gameEndText;

    public int playerOneScore
    {
        get { return _playerOneScore; }
        set
        {
            _playerOneScore = value;

            if (_playerOneScore > 9)
            {
                _playerOneScore = 10;
                _gameEndText.text = "PLAYER ONE WINS!";

                EndGame();
            }
            else
            {
                _ballDirection = 1;

                SpawnBall();
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

            if (_playerTwoScore > 9)
            {
                _playerTwoScore = 10;
                _gameEndText.text = "PLAYER TWO WINS!";

                EndGame();
            }
            else
            {
                _ballDirection = -1;

                SpawnBall();
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

    private void EndGame()
    {
        _playerOne.SetActive(false);
        _playerTwo.SetActive(false);
        _centerLine.SetActive(false);
        _playAgainButton.SetActive(true);
    }

    public void StartGame()
    {
        SpawnBall();
        _playerOne.SetActive(true);
        _playerTwo.SetActive(true);
        _centerLine.SetActive(true);
        _startGameButton.SetActive(false);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void SpawnBall()
    {
        Instantiate(_ball);
    }

    public void SpawnPickup()
    {
        Vector3 location = _pickupSpawnLocations[Mathf.FloorToInt(Random.Range(0, _pickupSpawnLocations.Count))].transform.position;

        switch (Mathf.FloorToInt(Random.Range(0, 4)))
        {
            case 0:
                Instantiate(_SpeedBooster, location, Quaternion.identity);
                break;
            case 1:
                Instantiate(_SpeedDamper, location, Quaternion.identity);
                break;
            case 2:
                Instantiate(_Obstacle, location, Quaternion.identity);
                break;
            case 3:
                Instantiate(_Splitter, location, Quaternion.identity);
                break;
        }
    }
}
