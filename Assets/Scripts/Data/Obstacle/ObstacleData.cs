using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleTemplate
{
    [CreateAssetMenu(fileName = "ObstacleData", menuName = "Data/Obstacle")]
    public sealed class ObstacleData : ScriptableObject
    {
        [SerializeField] private int _smallObstacleHP;
        [SerializeField] private int _middleObstacleHP;
        [SerializeField] private int _bigObstacleHP;
        [SerializeField] private int _longObstacleHP;
        [SerializeField] private int _towerObstacleHP;

        public int SmallObstacleHP { get { return _smallObstacleHP; } }
        public int MiddleObstacleHP { get { return _middleObstacleHP; } }
        public int BigObstacleHP { get { return _bigObstacleHP; } }
        public int LongObstacleHP { get { return _longObstacleHP; } }
        public int TowetObstacleHP { get { return _towerObstacleHP; } }
    }
}
