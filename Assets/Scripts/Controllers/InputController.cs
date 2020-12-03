using UnityEngine;


namespace ExampleTemplate
{
    public sealed class InputController : IExecute
    {
        private IThrowType _activeThrowType;
        private IThrowType[] _throwTypes;
        //todo убрать генератор платформ
        private PlatformGenerator _platformGenerator;
        private readonly KeyCode _escape = KeyCode.Escape;
        private readonly KeyCode _space = KeyCode.Space;
        private readonly int _leftButton = (int)MouseButton.LeftButton;
        private readonly int _rightButton = (int)MouseButton.RightButton;
        private readonly KeyCode _tab = KeyCode.Tab;
        private int _controllerCount = 0;
        //todo убрать шарик 

        public InputController( PlatformGenerator platformGenerator,params IThrowType[] throwTypes)
        {
            _platformGenerator = platformGenerator;
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;

            _throwTypes = throwTypes;
            _activeThrowType = _throwTypes[0];
        }

        #region IExecute

        public void Execute()
        {
            if (Input.GetKeyDown(_escape))
            {
                return;
            }

            if (Input.GetMouseButton(_leftButton))
            {
                _activeThrowType.GetMouseButton();
            }

            if (Input.GetMouseButtonUp(_leftButton))
            {
                _activeThrowType.GetMouseButtonUp();

            }

            if (Input.GetKeyDown(_tab))
            {
                ChangeGameMode();
            }

            if (Input.GetKeyDown(_space))
            {
                _platformGenerator.MovePlatforms();
            }
        }

        #endregion

        public void ChangeGameMode()
        {
            _controllerCount += 1;

            if (_controllerCount >= _throwTypes.Length)
            {
                _controllerCount = 0;
            }

            _activeThrowType = _throwTypes[_controllerCount];

            Services.Instance.CameraServices.SetCameraPosition(_activeThrowType.CameraPosition);
        }
    }
}