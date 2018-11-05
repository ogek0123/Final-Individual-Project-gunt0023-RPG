using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	private PlayerMovement Player;
	private CameraController Camera;

	public string SpawnName;

	// Use this for initialization
	void Start () {
		
		Player = FindObjectOfType<PlayerMovement> ();
		if (Player.startPoint == SpawnName) 
		{
			Camera = FindObjectOfType < CameraController> ();

			Player.transform.position = transform.position;

			Camera.transform.position = new Vector3 (transform.position.x, transform.position.y, Camera.transform.position.z);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
