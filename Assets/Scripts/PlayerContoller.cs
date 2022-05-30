using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] Rigidbody _playerRb;
    [SerializeField] Magnet magnetType;
    float _moveSpeed;
    SwervingMovement swerveMove;

    // Start is called before the first frame update
    void Start()
    {
        float _magnetSpeed = magnetType.MagnetSpeed;
        swerveMove = FindObjectOfType<SwervingMovement>();
        _moveSpeed = _magnetSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStatusCache == gameStatus.PLAY)
        {
            Movement();
            swerveMove.SwerveMove(_playerRb);
        }
        else if (GameManager.instance.gameStatusCache == gameStatus.CONTROLL)
        {
            _playerRb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void Movement()
    {
        _playerRb.velocity = new Vector3(_playerRb.velocity.x, _playerRb.velocity.y, _moveSpeed);
    }
}
