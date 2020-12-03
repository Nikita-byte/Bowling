using UnityEngine;
using System;


namespace ExampleTemplate
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform[] _cameraPositions;
        private Controllers _controllers;

        #endregion
        

        #region UnityMethods
        
        private void Start()
        {
            GameObject gameObject = Instantiate(Resources.Load<GameObject>(
                AssetsPathGameObject.GameObjects[GameObjectType.Shell]), Data.Instance.Shell.GetSpawnPosition(), Quaternion.identity);

            //todo убрать создание шарика и позицию из gameController

            _controllers = new Controllers(_cameraPositions);
            Initialization();
            //ScreenInterface.GetInstance().Execute(ScreenType.MainMenu);
        }

        private void Update()
        {
            for (var i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].Execute();
            }
        }

        #endregion

        public void Cleaner()
        {
            _controllers.Cleaner();
        }

        public void Initialization()
        {
            _controllers.Initialization();
        }
    }
}
