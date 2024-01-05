using UnityEngine;

public class CameraWork
{
    private Transform _camera;
    private float _dumping;

    public CameraWork(Transform cameraIn, float dumpingIn)
    {
        _camera = cameraIn;
        _dumping = dumpingIn;
    }

    public void Follow(Transform playerIn)
    {
        Vector3 target = new Vector3(playerIn.position.x, playerIn.position.y, _camera.position.z);

        Vector3 currentPosition = Vector3.Lerp(_camera.position, target, _dumping * Time.deltaTime);
        _camera.position = currentPosition;
    }
    public void ForcedFollow(Transform playerIn)
    {
        _camera.transform.position = playerIn.position;
    }
}
