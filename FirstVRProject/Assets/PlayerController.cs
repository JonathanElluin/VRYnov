using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int speed;
    public int rotationSpeed;
    public Camera myCamera;

    public float mouseSensitivity = 1000.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; 
    private float rotX = 0.0f;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        LookAtMouse();


        if (Input.GetKey(KeyCode.Z))
        {
           
            transform.position += transform.rotation * Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.rotation * Vector3.back * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += transform.rotation * Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.rotation * Vector3.right * Time.deltaTime * speed;
        }
       
    }

    void LookAtMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}
