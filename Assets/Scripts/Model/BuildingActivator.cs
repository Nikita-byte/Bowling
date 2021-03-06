﻿using UnityEngine;
using DG.Tweening;


namespace ExampleTemplate
{
    public sealed class BuildingActivator : MonoBehaviour
    {
        [SerializeField] private Color _targetColor = Color.white;
        [SerializeField] private Vector3 _targetPos = Vector3.zero;

        [SerializeField] private BuildingParams _buildingParams = null;
        [SerializeField] private Transform _target = null;
        [SerializeField] private GameObject _particleCollision = null;
        private BallModel _ball;

        [SerializeField] private BallDestroy _ballDestroy = BallDestroy.No;
        [SerializeField] private BuildingMoveType _buildingMoveType = BuildingMoveType.No;

        private void OnTriggerEnter(Collider other)
        {
            _ball = other.gameObject.GetComponent<BallModel>();

            if (_ball)
            {
                ChangeObjectColor();

                if (_buildingMoveType == BuildingMoveType.Move)
                {
                    MoveObject();
                }

                if (_buildingMoveType == BuildingMoveType.Rotate)
                {
                    RotateObject();
                }

                Instantiate(_particleCollision, gameObject.transform.position, Quaternion.identity);

                if (_ballDestroy == BallDestroy.Yes)
                {
                    DestroyBall();
                }
            }
        }

        private void ChangeObjectColor()
        {
            DOTween
                .Sequence()
                .Append(transform.GetComponent<Renderer>().material
                .DOColor(_targetColor, _buildingParams.Duration)
                .SetEase(_buildingParams.Ease));
        }

        private void MoveObject()
        {
            _target
                .DOMove(_targetPos, _buildingParams.Duration)
                .SetDelay(_buildingParams.Delay);
        }

        private void RotateObject()
        {
            _target
                .DORotate(_targetPos, _buildingParams.Duration)
                .SetDelay(_buildingParams.Delay);
        }

        private void DestroyBall()
        {
            Destroy(_ball.gameObject);
        }
    }
}
