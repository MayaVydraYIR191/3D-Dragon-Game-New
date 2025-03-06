using UnityEngine;

public class cameraControl : MonoBehaviour
{
    [SerializeField]
    private float mouseSense = 1f;
    private float yRotate;
    private float xRotate;
    

    private Vector3 currentRotate;

    [SerializeField]
    private Vector2 rotateMinMax = new Vector2(-40, 40);

    void OnMouseDrag()
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSense;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSense;

            yRotate += mouseX;
            xRotate += mouseY;

            xRotate = Mathf.Clamp(xRotate, rotateMinMax.x, rotateMinMax.y);
        }
    }
}
