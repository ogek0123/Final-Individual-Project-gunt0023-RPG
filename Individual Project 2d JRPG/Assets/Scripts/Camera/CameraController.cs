using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//camera can follow any target
	public GameObject followTarget;
	//movement speed of the camera
	public float CamMoveSpeed;
	//gets the current position of the target
	private Vector3 targetPos;

	private static bool CameraExists;

	void Start()
	{
		if (!CameraExists)
		{
			CameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else 
		{
			Destroy (gameObject);
		}


	}
	// Update is called once per frame
	void Update () {
		//gets the current position of the followTarget gameObject 
		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		//transform.position = camera's current positon and targetPos is where we want the camera to be
		transform.position = Vector3.Lerp (transform.position, targetPos, CamMoveSpeed * Time.deltaTime);

	}
}
