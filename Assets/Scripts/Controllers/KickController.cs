using UnityEngine;


namespace ExampleTemplate
{
    public class KickController : IThrowType
    {
        private float _angle = 0.0f;
        private Vector2 _direction;
        private bool _isActive;

        private BallModel _ballModel;
        private Camera _mainCamera;
        private UiShowBallTrajectory _uiShowBallTrajectory;

        public Transform CameraPosition { get; set; }

        public KickController(Transform cameraPosition)
        {
            _isActive = false;
            CameraPosition = cameraPosition;
            _ballModel = Object.FindObjectOfType<BallModel>();
            _mainCamera = Object.FindObjectOfType<Camera>();
        }

        public void GetMouseButton()
        {
            _direction = Input.mousePosition - _mainCamera.WorldToScreenPoint(_ballModel.transform.position);

            if (BallModel.IsActive == false)
            {
                _angle = -Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
                //_uiShowBallTrajectory.SliderDisplay(true);
                //_uiShowBallTrajectory.SliderCalculate(_angle, _direction.y);
            }
        }

        public void GetMouseButtonUp()
        {
            if (_ballModel != null)
            {
                _ballModel.GetComponent<Rigidbody>().useGravity = true;
                _ballModel.GetComponent<Rigidbody>().AddForce(Quaternion.LookRotation(new Vector3(_direction.x, 0, _direction.y))
                    * new Vector3(0, 0, Data.Instance.Shell.GetForce()), ForceMode.VelocityChange);

                _ballModel.ShootingBall();
                //_uiShowBallTrajectory.SliderDisplay(false);
                //_uiShowBallTrajectory.SliderValueReset();
            }
        }
    }

}
