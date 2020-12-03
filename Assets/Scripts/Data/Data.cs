using System;
using System.IO;
// using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;


namespace ExampleTemplate
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        #region Fields
        
        [SerializeField] private string _shakeDataPath;
        [SerializeField] private string _characterDataPath;
        [SerializeField] private string _shellDataPath;
        [SerializeField] private string _platformDataPath;
        [SerializeField] private string _obstacleDataPath;

        private static PlatformData _platformData;
        private static ShakesData _shake;
        private static CharacterData _characterData;
        private static ShellData _shellData;
        private static ObstacleData _obstacleData;
        private static readonly Lazy<Data> _instance = new Lazy<Data>(() => Load<Data>("Data/" + typeof(Data).Name));
      
        #endregion


        #region Properties

        public static Data Instance => _instance.Value;

        public ShakesData Shakes
        {
            get
            {
                if (_shake == null)
                {
                    _shake = Load<ShakesData>("Data/" + Instance._shakeDataPath);
                }

                return _shake;
            }
        }

        public CharacterData Character
        {
            get
            {
                if (_characterData == null)
                {
                    _characterData = Load<CharacterData>("Data/" + Instance._characterDataPath);
                }

                return _characterData;
            }
        }

        public ShellData Shell
        {
            get
            {
                if (_shellData == null)
                {
                    _shellData = Load<ShellData>("Data/" + Instance._shellDataPath);
                }

                return _shellData;
            }
        }

        public PlatformData Platform
        {
            get
            {
                if (_platformData == null)
                {
                    _platformData = Load<PlatformData>("Data/" + Instance._platformDataPath);
                }

                return _platformData;
            }
        }

        public ObstacleData Obstacle
        {
            get
            {
                if (_obstacleData == null)
                {
                    _obstacleData = Load<ObstacleData>("Data/" + Instance._obstacleDataPath);
                }

                return _obstacleData;
            }
        }


        #endregion


        #region Methods

        private static T Load<T>(string resourcesPath) where T : Object =>
            CustomResources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    
        #endregion
    }
}
