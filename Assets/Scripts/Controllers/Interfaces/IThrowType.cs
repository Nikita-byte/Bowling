using UnityEngine;


public interface IThrowType
{
    Transform CameraPosition { get; set; }

    void GetMouseButton();

    void GetMouseButtonUp();
}
