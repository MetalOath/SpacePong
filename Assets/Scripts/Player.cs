using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerIndex;
    [SerializeField]
    private float _moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if (_playerIndex == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * _moveSpeed);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.down * _moveSpeed);
            }
        }
        else if (_playerIndex == 2)
        {
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * _moveSpeed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.down * _moveSpeed);
            }
        }
    }


}
