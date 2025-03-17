using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    Transform player;
    public float sensitivity; 
    float xRotation;
    float yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        // test
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);   
        player.rotation = Quaternion.Euler(player.rotation.x, yRotation, player.rotation.z);
    }
}
