using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwervingMovement : SwervingController
{
    [SerializeField] private SwerveType swerveType;
    private float _swerveSpeed;
    private float _maxSwerveAmount;
    private float _maxMove_x;
    private Rigidbody _playerRb;

    private void Start()
    {
        _swerveSpeed = swerveType.SwerveSpeed;
        _maxSwerveAmount = swerveType.MaxSwerveAmount;
        _maxMove_x = swerveType.MaxMove_x;
    }

    public void SwerveMove(Rigidbody playerRb)
    {
        _playerRb = playerRb;
        CheckTouches();
        float _swerveAmount = _swerveSpeed * MoveFactorX;
        _swerveAmount = Mathf.Clamp(_swerveAmount, -_maxSwerveAmount, _maxSwerveAmount);
        _swerveAmount = EdgeController(_swerveAmount);
        _playerRb.velocity = new Vector3(_swerveAmount, _playerRb.velocity.y, _playerRb.velocity.z);
    }

    public float EdgeController(float swerveAmount)
    {
        swerveAmount = LeftLimitter(swerveAmount);
        swerveAmount = RightLimitter(swerveAmount);
        return swerveAmount;
    }

    public float LeftLimitter(float swerveAmount)
    {
        float _xPosition = _playerRb.transform.position.x;
        if (_xPosition <= -(_maxMove_x))
        {
            _playerRb.velocity = new Vector3(0, _playerRb.velocity.y, _playerRb.velocity.z);
            swerveAmount = Mathf.Clamp(swerveAmount, .1f, _maxSwerveAmount);
            return swerveAmount;
        }
        return swerveAmount;
    }
    public float RightLimitter(float swerveAmount)
    {
        float _xPosition = _playerRb.transform.position.x;
        if (_xPosition >= _maxMove_x)
        {
            _playerRb.velocity = new Vector3(0, _playerRb.velocity.y, _playerRb.velocity.z);
            swerveAmount = Mathf.Clamp(swerveAmount, -(_maxSwerveAmount), -.1f);
            return swerveAmount;
        }
        return swerveAmount;
    }
}
