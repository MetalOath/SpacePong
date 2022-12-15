using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int playerIndex;
    [SerializeField]
    private int moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIndex == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * moveSpeed);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.down * moveSpeed);
            }
        }
        else if (playerIndex == 2)
        {
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * moveSpeed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.down * moveSpeed);
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bounds"))
        {

        }
    }


}
