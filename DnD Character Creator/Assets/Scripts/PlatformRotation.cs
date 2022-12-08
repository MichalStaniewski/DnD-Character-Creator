using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float rotationSpeed = 25f;
    [SerializeField] private float defaultRotationSpeed = 10f;

    private bool mouseRotation = false;

    private Quaternion startRotation;

    [Header("References")]
    [SerializeField] private GameObject platform;

    private void Awake()
    {
        //storing the initial rotaion.
        startRotation = platform.transform.rotation;
    }

    private void Update()
    {
        //if the mouse isn't being used, rotate the platform with the default rotation speed.
        Vector3 _rotationRight = new Vector3(0, -1, 0);
        /*
        if (!mouseRotation)
        {
            platform.transform.Rotate(_rotationRight * defaultRotationSpeed * Time.deltaTime);
        } */       
    }

    private void OnMouseDown()
    {
        mouseRotation = true;
    }

    private void OnMouseDrag()
    {
        //rotating the platform with the mouse drag movement.
        float _rotationX = Input.GetAxis("Mouse X") * rotationSpeed;

        platform.transform.Rotate(Vector3.down, _rotationX);
    }

    private void OnMouseUp()
    {
        mouseRotation = false;
    }

    /// <summary>
    /// Reset the platforms rotation to the start rotation.
    /// </summary>
    public void ResetRotation()
    {
        platform.transform.rotation = startRotation;
    }
}
