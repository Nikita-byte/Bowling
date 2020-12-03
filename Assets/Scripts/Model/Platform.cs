using System;
using System.Collections.Generic;
using UnityEngine;


namespace ExampleTemplate
{
    public sealed class Platform : MonoBehaviour, IDestroyableObject
    {
        [SerializeField] private List<Transform> _bigSpawn;
        [SerializeField] private List<Transform> _middleSpawn;
        [SerializeField] private List<Transform> _smallSpawn;
        [SerializeField] private List<Transform> _longSpawn;
        [SerializeField] private List<Transform> _towerSpawn;
        
        private int _probabilityOfBigSpawn;
        private int _probabilityOfMiddleSpawn;
        private int _probabilityOfSmallSpawn;
        private int _probabilityOfLongSpawn;
        private int _probabilityOfTowerSpawn;
        private int _probabilityOfAimsOnPlatform;
        private int _maxPropability;
        private int _maxAimsOnPlatform;
        private int _aimsOnPlatform;
        private GameObject _tempObject;

        private List<Transform> _positionsForAims;
        private List<IDestroyableObject> _destroyableObjects;

        public GameObjectType GameObjectType { get; set; }

        private void Awake()
        {
            DataCache();

            _positionsForAims = new List<Transform>();
            _destroyableObjects = new List<IDestroyableObject>();
        }

        public void SetObjects()
        {
            System.Random rand = new System.Random();
            int temp;

            if (_bigSpawn != null)
            {
                SetObjectsOnSpawn(GameObjectType.BigObstacle);
            }

            if (_smallSpawn != null)
            {
                SetObjectsOnSpawn(GameObjectType.SmallObstacle);
            }

            if (_middleSpawn != null)
            {
                SetObjectsOnSpawn(GameObjectType.MiddleObstacle);
            }

            if (_longSpawn != null)
            {
                SetObjectsOnSpawn(GameObjectType.LongObstacle);
            }

            if (_towerSpawn != null)
            {
                SetObjectsOnSpawn(GameObjectType.TowersObstacles);
            }

            foreach (Transform position in _positionsForAims)
            {
                temp = rand.Next(_maxPropability);

                if (temp < _probabilityOfAimsOnPlatform)
                {
                    _tempObject = ObjectPool.Instance.GetRandomObjectFromPool(GameObjectType.Aim);

                    _tempObject.transform.position = position.position;
                    _tempObject.transform.SetParent(gameObject.transform);
                    _tempObject.SetActive(true);
                    _destroyableObjects.Add(_tempObject.GetComponent<Obstacle>() as IDestroyableObject);
                    (_tempObject.GetComponent<BotModel>() as IDestroyableObject).SetObjects();
                }
            }
        }

        public void SetObjectsOnSpawn(GameObjectType gameObjectType)
        {
            System.Random rand = new System.Random();
            int temp;

            switch (gameObjectType)
            {
                case GameObjectType.BigObstacle:
                    foreach (Transform position in _bigSpawn)
                    {
                        temp = rand.Next(_maxPropability);

                        if (temp < _probabilityOfBigSpawn)
                        {
                            SetObjectOnSpawn(GameObjectType.BigObstacle, position);
                        }
                        else
                        {
                            _positionsForAims.Add(position);
                        }
                    }
                    break;
                case GameObjectType.SmallObstacle:
                    foreach (Transform position in _smallSpawn)
                    {
                        temp = rand.Next(_maxPropability);

                        if (temp < _probabilityOfSmallSpawn)
                        {
                            SetObjectOnSpawn(GameObjectType.SmallObstacle, position);
                        }
                        else
                        {
                            _positionsForAims.Add(position);
                        }
                    }
                    break;
                case GameObjectType.LongObstacle:
                    foreach (Transform position in _longSpawn)
                    {
                        temp = rand.Next(_maxPropability);

                        if (temp < _probabilityOfLongSpawn)
                        {
                            SetObjectOnSpawn(GameObjectType.LongObstacle, position);
                        }
                        else
                        {
                            _positionsForAims.Add(position);
                        }
                    }
                    break;
                case GameObjectType.MiddleObstacle:
                    foreach (Transform position in _middleSpawn)
                    {
                        temp = rand.Next(_maxPropability);

                        if (temp < _probabilityOfMiddleSpawn)
                        {
                            SetObjectOnSpawn(GameObjectType.MiddleObstacle, position);
                        }
                        else
                        {
                            _positionsForAims.Add(position);
                        }
                    }
                    break;
                case GameObjectType.TowersObstacles:
                    foreach (Transform position in _towerSpawn)
                    {
                        temp = rand.Next(_maxPropability);

                        if (temp < _probabilityOfTowerSpawn)
                        {
                            SetObjectOnSpawn(GameObjectType.TowersObstacles, position);
                        }
                        else
                        {
                            _positionsForAims.Add(position);
                        }
                    }
                    break;
            }
        }

        public void SetObjectOnSpawn(GameObjectType gameObjectType, Transform position)
        {
            //todo перебрать
            _tempObject = ObjectPool.Instance.GetRandomObjectFromPool(gameObjectType);

            _tempObject.transform.position = position.position;
            _tempObject.transform.SetParent(gameObject.transform);
            _tempObject.SetActive(true);

            var temp = _tempObject.GetComponent<Obstacle>() as IDestroyableObject;

            if (temp != null)
            {
                _destroyableObjects.Add(_tempObject.GetComponent<Obstacle>() as IDestroyableObject);
                (_tempObject.GetComponent<Obstacle>() as IDestroyableObject).SetObjects();
            }
        }

        public void DestroyObject()
        {
            foreach (IDestroyableObject destroyableObject in _destroyableObjects)
            {
                if (destroyableObject != null)
                {
                    destroyableObject.DestroyObject();
                }
            }

            gameObject.SetActive(false);
            _positionsForAims.Clear();
            _destroyableObjects.Clear();

            ObjectPool.Instance.ReturnObjectInToThePool(gameObject, GameObjectType.Platform);
        }

        private void DataCache()
        {
            _probabilityOfBigSpawn = Data.Instance.Platform.ProbabilityOfBigSpawn;
            _probabilityOfMiddleSpawn = Data.Instance.Platform.ProbabilityOfMiddleSpawn;
            _probabilityOfSmallSpawn = Data.Instance.Platform.ProbabilityOfSmallSpawn;
            _probabilityOfTowerSpawn = Data.Instance.Platform.ProbabilityOfTowerSpawn;
            _probabilityOfLongSpawn = Data.Instance.Platform.ProbabilityOfLonglSpawn;
            _probabilityOfAimsOnPlatform = Data.Instance.Platform.ProbabilityOfAimsOnPlatform;
            _maxAimsOnPlatform = Data.Instance.Platform.MaxAimsOnPlatform;
            _maxPropability = Data.Instance.Platform.MaxPropability;
        }
    }
}
