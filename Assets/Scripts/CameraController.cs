using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    /*public Transform Object;
    public Transform orientation;

    public CinemachineFreeLook cam;*/

    public float panSpeed;
    public float zoomSpeed;
    private bool movementAllowed = true;

    public float minClamp;
    public float maxClamp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!movementAllowed)
            return;

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * zoomSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minClamp, maxClamp);

        transform.position = pos;

        

        /*Vector3 viewDirect = Object.position - new Vector3(transform.position.x, Object.position.y, transform.position.z);
        orientation.forward = viewDirect.normalized;

        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 inputDirect = (orientation.forward * vert) + (orientation.right * horiz);

        if (inputDirect != Vector3.zero)
            Object.forward = Vector3.Slerp(Object.forward, inputDirect.normalized, 0 or Time.deltaTime * rotationspeed);*/
    }
}
