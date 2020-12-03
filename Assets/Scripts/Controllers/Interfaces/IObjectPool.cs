using UnityEngine;


namespace ExampleTemplate
{
    public interface IObjectPool
    {
        GameObject ObjPool { get; set; }
        GameObject GetRandomObjectFromPool(GameObjectType gameObjectType);
        void ReturnObjectInToThePool(GameObject _object, GameObjectType gameObjectType);
    }
}
