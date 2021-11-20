using UnityEngine;

public static class CameraExtensions
{
    public static Bounds orthographicBounds(this Camera camera)
    {
        var screenAspect = Screen.width / (float)Screen.height;
        var cameraHeight = camera.orthographicSize * 2;
        var pos = new Vector2(camera.transform.position.x, camera.transform.position.y);
        var bounds = new Bounds(
            pos,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}
