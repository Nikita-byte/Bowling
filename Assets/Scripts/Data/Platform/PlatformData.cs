using UnityEngine;


namespace ExampleTemplate
{
    [CreateAssetMenu(fileName ="PlatformData", menuName ="Data/Platform")]
    public sealed class PlatformData : ScriptableObject
    {
        [SerializeField] private Vector3 _firstPlatformPosition;
        [SerializeField] private int _maxLongObstacles;
        [SerializeField] private int _maxBigObstacles;
        [SerializeField] private int _maxTowerObstacles;
        [SerializeField] private int _maxAimsOnPool;
        [SerializeField] private int _maxSmallObstacles;
        [SerializeField] private int _maxMiddleObstacle;
        [SerializeField] private int _maxPlatformOnScene;
        [SerializeField] private int _platformLength;
        [SerializeField] private float _distanceBetweenPlatforms;
        [SerializeField] private float _movePlatformDuration;
        [Range(0, 10), SerializeField] private int _probabilityOfBigSpawn;
        [Range(0, 10), SerializeField] private int _probabilityOfMiddleSpawn;
        [Range(0, 10), SerializeField] private int _probabilityOfSmallSpawn;
        [Range(0, 10), SerializeField] private int _probabilityOfLongSpawn;
        [Range(0, 10), SerializeField] private int _probabilityOfTowerSpawn;
        [Range(0, 10), SerializeField] private int _probabilityOfAimsOnPlatform;
        [Range(0, 5), SerializeField] private int _maxAimsOnPlatform;

        private int _maxPropability = 10;

        public Vector3 FirstPlatformPosition { get { return _firstPlatformPosition; } }
        public int MaxPropability { get { return _maxPropability; } }
        public int MaxBigObstacles { get { return _maxLongObstacles; } }
        public int MaxTowerObstacles { get { return _maxTowerObstacles; } }
        public int MaxLongObstacles { get { return _maxBigObstacles; } }
        public int MaxAimsOnPool { get { return _maxAimsOnPool; } }
        public int MaxSmallObstacles { get { return _maxSmallObstacles; } }
        public int MaxMiddleObstacle { get { return _maxMiddleObstacle; } }
        public int MaxPlatformOnScene { get { return _maxPlatformOnScene; } }
        public int PlatformLength { get { return _platformLength; } }
        public float DistanceBetweenPlatforms { get { return _distanceBetweenPlatforms; } }
        public int ProbabilityOfBigSpawn { get { return _probabilityOfBigSpawn; } }
        public int ProbabilityOfMiddleSpawn { get { return _probabilityOfMiddleSpawn; } }
        public int ProbabilityOfSmallSpawn { get { return _probabilityOfSmallSpawn; } }
        public int ProbabilityOfLonglSpawn { get { return _probabilityOfLongSpawn; } }
        public int ProbabilityOfTowerSpawn { get { return _probabilityOfLongSpawn; } }
        public int ProbabilityOfAimsOnPlatform { get { return _probabilityOfAimsOnPlatform; } }
        public float MovePlatformDuration { get { return _movePlatformDuration; } }
        public int MaxAimsOnPlatform { get { return _maxAimsOnPlatform; } }
    }
}
