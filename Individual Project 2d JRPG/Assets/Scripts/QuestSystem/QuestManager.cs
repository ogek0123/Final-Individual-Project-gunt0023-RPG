using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public QuestObject[] quests;
	public bool[] questCompleted;

	public DialgoueManager Dm;
	// Use this for initialization
	void Start () {
		questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowQuestText(string questText)
	{
		Dm.DialogLines = new string[1];
		Dm.DialogLines [0] = questText;

		Dm.currentLine = 0;
		Dm.ShowDialog ();
	}
}
