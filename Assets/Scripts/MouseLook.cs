using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public Transform Target;
    private float minimumCameraDistance = 5.0f;
    private float maximumCameraDistance = 50.0f;
    private float currentCameraDistance = 50.0f;
    private float minimumCameraPitch = 315.0f;
    private float maximumCameraPitch = 45.0f;
    private float speed = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    void FixedUpdate()
    {
        Vector3 pitchYawZoom = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetMouseButton(1) == true && Input.GetMouseButton(0) == false)
        {
            if(Input.GetAxis("Mouse Y") > 0.0f && transform.rotation.eulerAngles.x < maximumCameraPitch)
            {
                pitchYawZoom = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
            }
            else if(Input.GetAxis("Mouse Y") < 0.0f && transform.rotation.eulerAngles.x < maximumCameraPitch +10)
            {
                pitchYawZoom = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
            }
            else if (Input.GetAxis("Mouse Y") > 0.0f && transform.rotation.eulerAngles.x > minimumCameraPitch -10)
            {
                pitchYawZoom = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
            }
            else if (Input.GetAxis("Mouse Y") < 0.0f && transform.rotation.eulerAngles.x > minimumCameraPitch)
            {
                pitchYawZoom = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
            }

        }
        if (Input.GetMouseButton(1) == true && Input.GetMouseButton(0) == true)
        {
            if(Input.GetAxis("Mouse Y") < 0.0f && Vector3.Distance(transform.position, Target.transform.position) < maximumCameraDistance)
            pitchYawZoom = new Vector3(0.0f, 0.0f, Input.GetAxis("Mouse Y"));
            else if(Input.GetAxis("Mouse Y") > 0.0f && Vector3.Distance(transform.position, Target.transform.position) > minimumCameraDistance)
            pitchYawZoom = new Vector3(0.0f, 0.0f, Input.GetAxis("Mouse Y"));
        }
        transform.Translate((pitchYawZoom) * Time.deltaTime * speed);
        transform.LookAt(Target);
    }
}
