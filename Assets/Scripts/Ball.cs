using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float _startingForce, _bounceAdditiveForce;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        GetComponent<Rigidbody>().AddForce(Vector3.right * _startingForce * gameManager.ballDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Everytime a layer hits the ball, its speed increases slightly.
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().AddForce(collision.relativeVelocity * _bounceAdditiveForce);

            if (Random.value > 0.5)
                gameManager.SpawnPickup();
        }

        if (collision.gameObject.CompareTag("PlayerOneGoal"))
        {
            gameManager.playerOneScore++;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerTwoGoal"))
        {
            gameManager.playerTwoScore++;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBooster"))
        {
            Destroy(other.gameObject);

            GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * 2f);
        }

        if (other.CompareTag("SpeedDamper"))
        {
            Destroy(other.gameObject);

            GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * 0.5f);
        }

        if (other.CompareTag("Splitter"))
        {
            Destroy(other.gameObject);

            gameManager.SpawnBall();
        }
    }
}
