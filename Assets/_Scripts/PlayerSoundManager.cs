using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;

    private float _currentSpeed;
    private float _currentPitch;
    private MovementController _playerMovementController;

    private void Awake()
    {
        _playerMovementController = GetComponent<MovementController>();
    }

    private void Start()
    {
        _playerAudioSource.clip = Game.Instance.GetAudioClipsRefSO().TruckSound;
        _playerAudioSource.Play();
    }

    private void Update()
    {
        _currentSpeed = _playerMovementController.GetSpeed();
        _currentPitch = _playerMovementController.GetSpeed() / 400f;

        if (_currentSpeed < _minSpeed)
        {
            _currentPitch = _minPitch;
        }
        else if( _currentSpeed > _maxSpeed)
        {
            _currentPitch = _maxPitch;
        }
        else
        {
            _currentPitch = _minPitch + _currentPitch;
        }

        _playerAudioSource.pitch = _currentPitch;
    }

}
