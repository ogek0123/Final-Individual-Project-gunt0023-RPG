using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	private DialgoueManager Dman;

	public string[] dialogueLines;
	//private PlayerMovement pm;
	void Start () {
		Dman = FindObjectOfType<DialgoueManager> ();
		//pm = FindObjectOfType<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			if (Input.GetKeyUp (KeyCode.Space)) 
			{
				//Dman.ShowBox (dialogue);
				if (!Dman.DialogActive) 
				{
					Dman.DialogLines = dialogueLines;
					Dman.currentLine = 0;
					Dman.ShowDialog ();
					//pm.MovementSpeed = 0f;

				}

			}


		}

	}
}
