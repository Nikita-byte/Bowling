using UnityEngine;

namespace ExampleTemplate
{
    public sealed class GameBoundary : MonoBehaviour
    {
        [SerializeField] private GameObject _destroyBallParticle = null;
        private BallModel _ball;

        private void OnTriggerExit(Collider other)
        {
            _ball = other.GetComponent<BallModel>();

            if (_ball)
            {
                _ball.DestroyBall();
            }
        }
    }
}
