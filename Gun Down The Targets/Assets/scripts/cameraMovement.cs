using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    [Header("sensitivity")]
    public float sensX = 400f;
    public float sensY = 400f;

    [Header("rotation")]
    public float rotationX;
    public float rotationY;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //locks cursor and makes it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        //gives rotation correct value
        rotationY += mouseX;
        rotationX -= mouseY;

        // locks camera movement verticaly
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        //rotaties the camera
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        player.rotation = Quaternion.Euler(0, rotationY, 0);
    }

}

