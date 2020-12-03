using UnityEngine;
using System;
using System.Collections.Generic;


namespace ExampleTemplate
{
    public sealed class Obstacle : MonoBehaviour, IBuilding, IDestroyableObject
    {
        //todo возврат в пул

        [SerializeField] private GameObjectType _gameObjectType;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private GameObject _smallParticles;
        [SerializeField] private GameObject _destroyParticles;
        [SerializeField] private int _maxAimsOnObstacle;
        [Range(0, 10), SerializeField] private int _chanceOfSpawnAims;

        private int _HP;
        private bool _isHit;
        private int _maxPropability;
        private List<IDestroyableObject> _destroyableObjects;
        private GameObject _tempObject;

        public Transform[] SpawnPoints { get { return _spawnPoints; } }
        public GameObjectType GameObjectType { get { return _gameObjectType; } set { } }

        public void Awake()
        {
            _maxPropability = Data.Instance.Platform.MaxPropability;
            _destroyableObjects = new List<IDestroyableObject>();

            UpdateHP();
        }

        //public void Start()
        //{
        //    _maxPropability = Data.Instance.Platform.MaxPropability;

        //    UpdateHP();
        //}

        public void SetObjects()
        {
            if (_spawnPoints != null)
            {
                System.Random rand = new System.Random();
                int temp;

                foreach (Transform spawnPoint in _spawnPoints)
                {
                    temp = rand.Next(_maxPropability);

                    if (temp < _chanceOfSpawnAims)
                    {
                        _tempObject = ObjectPool.Instance.GetRandomObjectFromPool(GameObjectType.Aim);

                        _tempObject.transform.position = spawnPoint.position;
                        _tempObject.transform.SetParent(gameObject.transform);
                        _tempObject.SetActive(true);

                        var tempDestr = _tempObject.GetComponent<BotModel>() as IDestroyableObject;

                        if (tempDestr != null)
                        {
                            _destroyableObjects.Add(tempDestr);
                        }
                    }
                }
            }
        }

        public void DestroyObject()
        {
            foreach (IDestroyableObject destroyableObject in _destroyableObjects)
            {
                destroyableObject.DestroyObject();
            }

            gameObject.SetActive(false);
            Instantiate(_destroyParticles, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            UpdateHP();

            _destroyableObjects.Clear();

            ObjectPool.Instance.ReturnObjectInToThePool(gameObject, GameObjectType);
        }

        private void OnTriggerEnter(Collider other)
        {
            BallModel _ballModel = other.gameObject.GetComponent<BallModel>();

            if (_ballModel != null)
            {
                if (!_isHit)
                {
                    DestroyObject();
                }
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            if (!_isHit)
            {
                _HP = _HP - 1;

                if (_HP == 0)
                {
                    GetComponent<Collider>().isTrigger = true;
                    DestroyObject();
                }
                else
                {
                    _isHit = true;
                    Invoke("TurnIsHit", 0.5f);
                }
            }
        }

        private void OnParticleTrigger()
        {
            if (!_isHit)
            {
                _HP = _HP - 1;

                if (_HP == 0)
                {
                    GetComponent<Collider>().isTrigger = true;
                    DestroyObject();
                }
                else
                {
                    _isHit = true;
                    Invoke("TurnIsHit", 0.5f);
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            BallModel _ballModel = collision.gameObject.GetComponent<BallModel>();

            if (_ballModel != null)
            {
                if (!_isHit)
                {
                    _HP = _HP - 1;

                    if (_HP == 0)
                    {
                        GetComponent<Collider>().isTrigger = true;
                        DestroyObject();
                    }
                    else
                    {
                        Instantiate(_smallParticles, collision.GetContact(0).point, Quaternion.Euler(0, 180, 0));
                        collision.gameObject.GetComponent<Rigidbody>().
                         AddForce(Vector3.Reflect(collision.gameObject.transform.forward, collision.GetContact(0).normal) * 30, ForceMode.Impulse);

                        _isHit = true;
                        Invoke("TurnIsHit", 0.5f);
                    }
                }
            }
        }

        private void TurnIsHit()
        {
            _isHit = !_isHit;
        }

        public void UpdateHP()
        {
            switch (_gameObjectType)
            {
                case GameObjectType.SmallObstacle:
                    _HP = Data.Instance.Obstacle.SmallObstacleHP;
                    break;
                case GameObjectType.MiddleObstacle:
                    _HP = Data.Instance.Obstacle.MiddleObstacleHP;
                    break;
                case GameObjectType.BigObstacle:
                    _HP = Data.Instance.Obstacle.BigObstacleHP;
                    break;
                case GameObjectType.LongObstacle:
                    _HP = Data.Instance.Obstacle.LongObstacleHP;
                    break;
                case GameObjectType.TowersObstacles:
                    _HP = Data.Instance.Obstacle.TowetObstacleHP;
                    break;
            }

            if (_HP == 0)
            {
                GetComponent<MeshCollider>().isTrigger = true;
            }
            else
            {
                GetComponent<MeshCollider>().isTrigger = false;
            }
        }
    }
}
