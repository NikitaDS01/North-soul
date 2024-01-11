using System.Collections;
using UnityEngine;

[System.Serializable]
public class CameraWork : IService
{
    [SerializeField] private Transform _camera;
    [SerializeField, Min(0)] private float _dumping;
    [SerializeField] private Vector2 _offset;
    public CameraWork(Transform cameraIn, float dumpingIn, Vector2 offset)
    {
        _camera = cameraIn;
        _dumping = dumpingIn;
        _offset = offset;
    }

    public void Follow(Transform playerIn)
    {
        Vector3 target = new Vector3(
            playerIn.position.x + _offset.x, 
            playerIn.position.y + _offset.y, 
            _camera.position.z);

        Vector3 currentPosition = Vector3.Lerp(_camera.position, target, _dumping * Time.deltaTime);
        _camera.position = currentPosition;
    }
    public IEnumerator ForcedFollowSecond(Transform playerIn, float secondIn)
    {
        yield return new WaitForSeconds(secondIn);
        _camera.transform.position = new Vector3(
            playerIn.position.x + _offset.x,
            playerIn.position.y + _offset.y,
            _camera.position.z);
    }
    public void ForcedFollow(Transform playerIn)
    {
        _camera.transform.position = new Vector3(
            playerIn.position.x + _offset.x,
            playerIn.position.y + _offset.y,
            _camera.position.z);
    }
}
