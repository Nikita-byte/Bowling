using UnityEngine;


namespace ExampleTemplate
{
    public sealed class BallModel : MonoBehaviour
    {
        private ShellData _shellData;

        public static bool IsActive;

        [SerializeField] private GameObject _destroyBallParticle = null;
        private Rigidbody _ballRigidbody;

        [SerializeField] private BallType _ball = BallType.NormalBall;

        private void Start()
        {
            _shellData = Data.Instance.Shell;
            _ballRigidbody = GetComponent<Rigidbody>();
            _ballRigidbody.useGravity = false;
            IsActive = false;
        }

        public void ShootingBall()
        {
            if (IsActive == false && _ball == BallType.NormalBall)
            {
                IsActive = true;
            }
            //Invoke(nameof(DestroyBall), _destroyBallByTime);

            if (IsActive == false && _ball == BallType.ExplodingBall)
            {
                return;
            }
        }

        public void DestroyBall()
        {
            // todo переделать обновление шарика
            _ballRigidbody.isKinematic = true;
            _ballRigidbody.isKinematic = false;
            gameObject.transform.rotation = Quaternion.identity;
            _ballRigidbody.velocity = Vector3.zero;
            gameObject.transform.position = _shellData.GetSpawnPosition();
            Instantiate(_destroyBallParticle, gameObject.transform.position, Quaternion.identity);
            //IsActive = false;
        }
    }
}
