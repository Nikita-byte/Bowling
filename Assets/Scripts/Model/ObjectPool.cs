using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleTemplate
{
    public sealed class ObjectPool : IObjectPool
    {
        private static readonly ObjectPool _instance = new ObjectPool();

        private readonly string POOLNAME = "Pool";
        private List<GameObject> _platforms;
        private List<GameObject> _bigObstacles;
        private List<GameObject> _middleObstacles;
        private List<GameObject> _smallObstacles;
        private List<GameObject> _longObstacles;
        private List<GameObject> _towerObstacles;
        private List<GameObject> _aims;

        private int _temp;
        private System.Random _rand;
        private GameObject _tempObject;

        public static ObjectPool Instance { get { return _instance; } }
        public GameObject ObjPool { get; set; }

        public ObjectPool()
        {
            ObjPool = new GameObject(POOLNAME);

            _rand = new System.Random();

            CreateAims();
            CreateObstacles();
            CreatePlatforms();
        }

        public GameObject GetRandomObjectFromPool(GameObjectType gameObjectType)
        {
            switch (gameObjectType)
            {
                case GameObjectType.Platform:
                    _temp = _rand.Next(_platforms.Count);
                    _tempObject = _platforms[_temp];
                    _platforms.RemoveAt(_temp);
                    return _tempObject;
                case GameObjectType.BigObstacle:
                    _temp = _rand.Next(_bigObstacles.Count);
                    _tempObject = _bigObstacles[_temp];
                    _bigObstacles.RemoveAt(_temp);
                    return _tempObject;
                case GameObjectType.SmallObstacle:
                    _temp = _rand.Next(_smallObstacles.Count);
                    _tempObject = _smallObstacles[_temp];
                    _smallObstacles.RemoveAt(_temp);
                    return _tempObject;
                case GameObjectType.MiddleObstacle:
                    _temp = _rand.Next(_middleObstacles.Count);
                    _tempObject = _middleObstacles[_temp];
                    _middleObstacles.RemoveAt(_temp);
                    return _tempObject;
                case GameObjectType.LongObstacle:
                    _temp = _rand.Next(_longObstacles.Count);
                    _tempObject = _longObstacles[_temp];
                    _longObstacles.RemoveAt(_temp);
                    return _tempObject;
                case GameObjectType.TowersObstacles:
                    _temp = _rand.Next(_towerObstacles.Count);
                    _tempObject = _towerObstacles[_temp];
                    _towerObstacles.RemoveAt(_temp);
                    return _tempObject;
                case GameObjectType.Aim:
                    _temp = _rand.Next(_aims.Count);
                    _tempObject = _aims[_temp];
                    _aims.RemoveAt(_temp);
                    return _tempObject;

            }
            return null;
        }

        public void ReturnObjectInToThePool(GameObject _object, GameObjectType gameObjectType)
        {
            switch (gameObjectType)
            {
                case GameObjectType.BigObstacle:
                    _bigObstacles.Add(_object);
                    break;
                case GameObjectType.SmallObstacle:
                    _smallObstacles.Add(_object);
                    break;
                case GameObjectType.MiddleObstacle:
                    _middleObstacles.Add(_object);
                    break;
                case GameObjectType.LongObstacle:
                    _longObstacles.Add(_object);
                    break;
                case GameObjectType.TowersObstacles:
                    _towerObstacles.Add(_object);
                    break;
                case GameObjectType.Aim:
                    _aims.Add(_object);
                    break;
                case GameObjectType.Platform:
                    _platforms.Add(_object);
                    break;
            }
        }

        public void CreateAims()
        {
            _aims = new List<GameObject>();

            GameObject[] objs = Resources.LoadAll<GameObject>(AssetsPathGameObject.GameObjects[GameObjectType.Aim]);

            int i = 0;
            while (i < Data.Instance.Platform.MaxAimsOnPool)
            {
                foreach (var obj in objs)
                {
                    _aims.Add(GameObject.Instantiate(obj, Vector3.zero, Quaternion.Euler(new Vector3(0, 180, 0))));
                    i++;
                }
            }

            foreach (var obj in _aims)
            {
                obj.SetActive(false);
                obj.transform.SetParent(ObjPool.transform);
            }
        }

        public void CreateObstacles()
        {
            _bigObstacles = new List<GameObject>();
            _smallObstacles = new List<GameObject>();
            _middleObstacles = new List<GameObject>();
            _longObstacles = new List<GameObject>();
            _towerObstacles = new List<GameObject>();

            GameObject[] objs = Resources.LoadAll<GameObject>(AssetsPathGameObject.GameObjects[GameObjectType.BigObstacle]);
            int i = 0;

            if (objs.Length != 0)
            {
                i = 0;
                while (i < Data.Instance.Platform.MaxBigObstacles)
                {
                    foreach (var obj in objs)
                    {
                        _bigObstacles.Add(GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity));
                        i++;
                    }
                }
            }

            objs = Resources.LoadAll<GameObject>(AssetsPathGameObject.GameObjects[GameObjectType.SmallObstacle]);

            if (objs.Length != 0)
            {
                i = 0;
                while (i < Data.Instance.Platform.MaxSmallObstacles)
                {
                    foreach (var obj in objs)
                    {
                        _smallObstacles.Add(GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity));
                        i++;
                    }
                }
            }

            objs = Resources.LoadAll<GameObject>(AssetsPathGameObject.GameObjects[GameObjectType.MiddleObstacle]);

            if (objs.Length != 0)
            {
                i = 0;
                while (i < Data.Instance.Platform.MaxMiddleObstacle)
                {
                    foreach (var obj in objs)
                    {
                        _middleObstacles.Add(GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity));
                        i++;
                    }
                }
            }

            objs = Resources.LoadAll<GameObject>(AssetsPathGameObject.GameObjects[GameObjectType.LongObstacle]);

            if (objs.Length != 0)
            {
                i = 0;
                while (i < Data.Instance.Platform.MaxLongObstacles)
                {
                    foreach (var obj in objs)
                    {
                        _longObstacles.Add(GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity));
                        i++;
                    }
                }
            }

            objs = Resources.LoadAll<GameObject>(AssetsPathGameObject.GameObjects[GameObjectType.TowersObstacles]);

            if (objs.Length != 0)
            {
                i = 0;
                while (i < Data.Instance.Platform.MaxTowerObstacles)
                {
                    foreach (var obj in objs)
                    {
                        _towerObstacles.Add(GameObject.Instantiate(obj, Vector3.zero, Quaternion.Euler(new Vector3(0,0,0))));
                        i++;
                    }
                }
            }

            foreach (var obj in _smallObstacles)
            {
                obj.SetActive(false);
                obj.transform.SetParent(ObjPool.transform);
            }
            foreach (var obj in _middleObstacles)
            {
                obj.SetActive(false);
                obj.transform.SetParent(ObjPool.transform);
            }
            foreach (var obj in _bigObstacles)
            {
                obj.SetActive(false);
                obj.transform.SetParent(ObjPool.transform);
            }
            foreach (var obj in _longObstacles)
            {
                obj.SetActive(false);
                obj.transform.SetParent(ObjPool.transform);
            }
            foreach (var obj in _towerObstacles)
            {
                obj.SetActive(false);
                obj.transform.SetParent(ObjPool.transform);
            }
        }

        public void CreatePlatforms()
        {
            _platforms = new List<GameObject>();

            for (int i = 0; i < Data.Instance.Platform.PlatformLength; i++)
            {
                var temp = Resources.LoadAll<GameObject>(AssetsPathGameObject.GameObjects[GameObjectType.Platform]);

                foreach (var tem in temp)
                {
                    _platforms.Add(GameObject.Instantiate(tem, Vector3.zero, Quaternion.identity));
                }
                //_platforms.Add(GameObject.Instantiate(temp, Vector3.zero, Quaternion.identity));
                //_platforms.Add(GameObject.Instantiate(Resources.Load<GameObject>(AssetsPathGameObject.GameObjects[GameObjectType.Platform]), Vector3.zero, Quaternion.identity));
            }

            foreach (GameObject platform in _platforms)
            {
                platform.transform.SetParent(ObjPool.transform);
                platform.gameObject.SetActive(false);
            }

            //for (int i = Data.Instance.Platform.EasyPlatformLength; i < Data.Instance.Platform.NormalPlatformLenght + Data.Instance.Platform.EasyPlatformLength; i++)
            //{
            //    _platforms.Add(GameObject.Instantiate(Resources.Load<GameObject>(AssetsPathGameObject.GameObjects[GameObjectType.NormalPlatform]), Vector3.zero, Quaternion.identity));
            //    _platforms[i].transform.SetParent(ObjPool.transform);
            //    _platforms[i].SetActive(false);
            //}

            //for (int i = Data.Instance.Platform.NormalPlatformLenght + Data.Instance.Platform.EasyPlatformLength;
            //    i < Data.Instance.Platform.NormalPlatformLenght + Data.Instance.Platform.EasyPlatformLength + Data.Instance.Platform.HardPlatformLength; i++)
            //{
            //    _platforms.Add(GameObject.Instantiate(Resources.Load<GameObject>(AssetsPathGameObject.GameObjects[GameObjectType.HardPlatform]), Vector3.zero, Quaternion.identity));
            //    _platforms[i].transform.SetParent(ObjPool.transform);
            //    _platforms[i].SetActive(false);
            //}
        }
    }
}
