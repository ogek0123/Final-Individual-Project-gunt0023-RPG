using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

	public int questNumber;

	public QuestManager Qm;

	public string startText;
	public string endText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartQuest()
	{
		Qm.ShowQuestText (startText);

	}

	public void EndQuest()
	{
		Qm.ShowQuestText (endText);
		Qm.questCompleted [questNumber] = true;
		gameObject.SetActive (false);

	}
}
