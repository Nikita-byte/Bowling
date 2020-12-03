using UnityEngine;


namespace ExampleTemplate
{
    [CreateAssetMenu(fileName = "ShellData", menuName = "Data/ShellData")]
    public sealed class ShellData : ScriptableObject
    {
        [SerializeField] private float _forceBall;
        [SerializeField] private Vector3 _spawnPosition;
        [SerializeField] private Transform transform;

        public float GetForce()
        {
            return _forceBall;
        }

        public Vector3 GetSpawnPosition()
        {
            return _spawnPosition;
        }
    }
}


