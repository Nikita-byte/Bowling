using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace ExampleTemplate
{
    public sealed class PlatformGenerator : IInitialization
    {
        private Transform[] _platformPoints;
        private int _maxPlatformOnScene;
        private float _distanceBetweenPlatforms;
        private float _movePlatformDuration;

        private GameObject[] _activePlatforms;

        public PlatformGenerator()
        {
            DataCache();
            _platformPoints = new Transform[_maxPlatformOnScene];
            GameObject temp;

            for (int i = 0; i < _maxPlatformOnScene; i++)
            {
                temp = new GameObject();
                temp.transform.position = Data.Instance.Platform.FirstPlatformPosition;
                _platformPoints[i] = temp.transform;
            }
        }

        public void Initialization()
        {
            for (int i = 1; i < _platformPoints.Length; i++)
            {
                _platformPoints[i].Translate(_platformPoints[i - 1].position + new Vector3(0,0, _distanceBetweenPlatforms));
            }

            CreatePlatforms();
            SetPlatforms();

            //InvokeRepeating("MovePlatforms", 0.0f, 3f);
        }

        public void SetPlatforms()
        {
            for (int i = 0; i < _activePlatforms.Length; i++)
            {
                _activePlatforms[i].SetActive(true);
                _activePlatforms[i].transform.position = _platformPoints[i].position;
            }
        }

        public void MovePlatforms()
        {
            for (int i = 0; i < _maxPlatformOnScene; i++)
            {
                if (i == 0)
                {
                    (_activePlatforms[i].GetComponent<Platform>() as IDestroyableObject).DestroyObject();
                    _activePlatforms.RemoveAt(i);
                }
                else
                {
                    _activePlatforms[i].transform.DOMove(_platformPoints[i - 1].position,_movePlatformDuration);
                    _activePlatforms[i - 1] = _activePlatforms[i];
                }
            }

            System.Random rand = new System.Random();

            _activePlatforms[_maxPlatformOnScene - 1] = ObjectPool.Instance.GetRandomObjectFromPool(GameObjectType.Platform); ;

            SetObjectsOnPlatform(_maxPlatformOnScene - 1);

            _activePlatforms[_maxPlatformOnScene - 1].transform.position = _platformPoints[_maxPlatformOnScene - 1].position;
            _activePlatforms[_maxPlatformOnScene - 1].SetActive(true);
        }

        public void CreatePlatforms()
        {
            _activePlatforms = new GameObject[_maxPlatformOnScene];

            for (int i = 0; i < _maxPlatformOnScene; i++)
            {
                _activePlatforms[i] = ObjectPool.Instance.GetRandomObjectFromPool(GameObjectType.Platform);

                SetObjectsOnPlatform(i);
            }
        }

        public void SetObjectsOnPlatform(int number)
        {
            var tempPlatform = _activePlatforms[number].GetComponent<Platform>() as IDestroyableObject;
            tempPlatform.SetObjects();
        }

        private void DataCache()
        {
            _maxPlatformOnScene = Data.Instance.Platform.MaxPlatformOnScene;
            _distanceBetweenPlatforms = Data.Instance.Platform.DistanceBetweenPlatforms;
            _movePlatformDuration = Data.Instance.Platform.MovePlatformDuration;
        }
    }
}
