using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace ExampleTemplate
{
    public class HoleModel : MonoBehaviour
    {
        [SerializeField] private BuildingParams _params;
        [SerializeField] private float _time;

        private BallModel _ball;

        private void OnTriggerEnter(Collider other)
        {
            _ball = other.GetComponent<BallModel>();

            if (_ball)
            {
                _ball.transform.DOMove(transform.position, _params.Duration);
                Invoke("DestroyObjectInHole", _time);
            }
        }

        public void DestroyObjectInHole()
        {
            //_ball.DestroyBall();
        }
    }
}

