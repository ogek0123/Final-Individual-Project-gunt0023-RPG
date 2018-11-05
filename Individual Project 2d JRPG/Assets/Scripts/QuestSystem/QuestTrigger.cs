using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

	private QuestManager Qm;

	public int questNumber;

	public bool startQuest;

	public bool endQuest;



	void Start () {
		Qm = FindObjectOfType<QuestManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			if (!Qm.questCompleted [questNumber]) 
			{
				if (startQuest && !Qm.quests [questNumber].gameObject.activeSelf) 
				{
					Qm.quests [questNumber].gameObject.SetActive (true);
					Qm.quests [questNumber].StartQuest ();
				}

				if (endQuest && Qm.quests [questNumber].gameObject.activeSelf) 
				{
					Qm.quests [questNumber].EndQuest ();
				}

			}

		}

	}
}
