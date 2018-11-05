using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAlive : MonoBehaviour {

	public bool isAlive = true;
	// Use this for initialization
	void Start () {
		if (isAlive == false) 
		{
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.name == "Player") 
		{
			Destroy (gameObject);
			isAlive = false;
			Debug.Log (isAlive);
			//print ("hi");
		}

	}
}
