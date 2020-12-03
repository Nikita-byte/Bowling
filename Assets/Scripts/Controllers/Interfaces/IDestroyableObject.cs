using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleTemplate
{
    public interface IDestroyableObject
    {
        GameObjectType GameObjectType { get; set; }

        void SetObjects();

        void DestroyObject();
    }
}
