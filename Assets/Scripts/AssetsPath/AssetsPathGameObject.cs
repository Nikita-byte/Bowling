using System.Collections.Generic;


namespace ExampleTemplate
{
    public sealed class AssetsPathGameObject
    {
        #region Fields

        public static readonly Dictionary<GameObjectType, string> GameObjects = new Dictionary<GameObjectType, string>
        {
            {
                GameObjectType.Canvas, "GUI/GUI_Canvas"
            },
            {                
                GameObjectType.Character, "Prefabs/Character/Prefabs_Character_SphereCharacter"
            },
            {
                GameObjectType.Shell,  "Prefab/Ball_1"
            },
            {
                GameObjectType.Platform, "Prefab/Platforms"
            },
            {
                GameObjectType.BigObstacle, "Prefab/Obstacles/BigObstacles"
            },
            {
                GameObjectType.SmallObstacle, "Prefab/Obstacles/SmallObstacles"
            },
            {
                GameObjectType.MiddleObstacle, "Prefab/Obstacles/MiddleObstacles"
            },
            {
                GameObjectType.LongObstacle, "Prefab/Obstacles/LongObstacles"
            },
            {
                GameObjectType.TowersObstacles, "Prefab/Obstacles/Towers"
            },
            {
                GameObjectType.Aim, "Prefab/Aims"
            }
        };

        #endregion
    }
}
