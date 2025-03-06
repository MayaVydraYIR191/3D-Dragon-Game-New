using UnityEngine;

public class Shot : MonoBehaviour
{
    public float offSet;
    public GameObject shot;
    public Transform shotPoint;

    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(180, 0, 0);
        }

        Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offSet);
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(shot, shotPoint.position, shotPoint.rotation);
        }

    }

}