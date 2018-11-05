using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialgoueManager : MonoBehaviour {

	public GameObject DialogBox;
	public Text DialogText;

	public bool DialogActive;

	public string[] DialogLines;
	public int currentLine;

	private PlayerMovement pm;
	void Start () {
		pm = FindObjectOfType<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (DialogActive && Input.GetKeyDown (KeyCode.Space)) 
		{
			//DialogBox.SetActive (false);
			//DialogActive = false;
			currentLine++;
		}

		if (currentLine >= DialogLines.Length) 
		{
			DialogBox.SetActive (false);
			DialogActive = false;
			//pm.MovementSpeed = 5f;
			currentLine = 0;
		}
		DialogText.text = DialogLines [currentLine];

		if (DialogActive == true) {
			pm.MovementSpeed = 0f;

		}

		if (DialogActive == false) {
			pm.MovementSpeed = 5f;

		}
	}

	public void ShowBox(string dialog)
	{
		DialogActive = true;
		//pm.MovementSpeed = 0f;
		DialogBox.SetActive (true);

		DialogText.text = dialog;



	}

	public void ShowDialog()
	{
		DialogActive = true;
		DialogBox.SetActive (true);
		//pm.MovementSpeed = 0f;

	}
}
