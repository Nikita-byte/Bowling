using UnityEngine;


namespace ExampleTemplate
{
    public sealed class ThrowСontroller : IThrowType
    {
        private float _high = 0.0f;
        private float _angle = 0.0f;
        private Vector2 _direction;
        private Vector2 _firstPoint;
        private Vector2 _secondPoint;
        private bool _isPushed = false;

        private BallModel _ballModel = Object.FindObjectOfType<BallModel>();

        public Transform CameraPosition { get; set; }

        public ThrowСontroller(Transform cameraPosition)
        {
            CameraPosition = cameraPosition;
        }

        public void GetMouseButton()
        {
            if (!_isPushed)
            {
                _firstPoint = Input.mousePosition;
                _isPushed = true;
            }
        }

        public void GetMouseButtonUp()
        {
            _secondPoint = Input.mousePosition;

            _direction = _secondPoint - _firstPoint;
            _angle = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
            _high = _direction.y * 45.0f / Screen.height;

            if (_ballModel != null)
            {
                _ballModel.GetComponent<Rigidbody>().useGravity = true;

                _ballModel.gameObject.transform.rotation = Quaternion.Euler(new Vector3(-_high, _angle, 0));

                _ballModel.GetComponent<Rigidbody>().AddForce(_ballModel.gameObject.transform.forward * 40, ForceMode.Impulse);

                _high = 0.0f;
                _isPushed = false;

                _ballModel.ShootingBall();
            }
        }
    }
}

