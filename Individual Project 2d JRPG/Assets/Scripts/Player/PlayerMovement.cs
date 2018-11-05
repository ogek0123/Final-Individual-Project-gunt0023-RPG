using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float MovementSpeed = 3f;

	//refernce to Animator
	private Animator anim;

	private static bool PlayerExists;

	public string startPoint;

	public Inventory inventory;

	void Start () {

		if (!PlayerExists)
		{
			PlayerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else 
		{
			Destroy (gameObject);
		}

		//Get the animator componenet that is on the same object as this script is attached to
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
// if Input on the horizontal axis which is 'd' or 'a' on keyboard 
		// move in the x direction based on the movementspeed
		if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < 0.5f)
			{
			transform.Translate(new Vector3 (Input.GetAxisRaw("Horizontal") * MovementSpeed * Time.deltaTime, 0f, 0f));

			}
		// if Input on the vertical axis which is 'w' or 's' on keyboard 
		// move in the y direction based on the movementspeed
		if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < 0.5f)
		{
			transform.Translate(new Vector3 (0f,Input.GetAxisRaw("Vertical") * MovementSpeed * Time.deltaTime, 0f));

		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
	}

	/*void OnControllerColliderHit(ControllerColliderHit hit)
	{
		print ("hello there");
		IInventoryItem item = hit.collider.GetComponent<IInventoryItem> ();
		if (item != null) 
		{
			inventory.AddItem (item);
			print ("hello there");
		}

	}*/
	void OnTriggerEnter2D(Collider2D other)
	{
		print (" there");
		if (other.name == "Sword") {
			IInventoryItem item = other.GetComponent<IInventoryItem> ();
			if (item != null) {
				inventory.AddItem (item);
				print ("hello there");
			}
		}
	}
}
