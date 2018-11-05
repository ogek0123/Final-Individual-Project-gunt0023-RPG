using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMapTester : MonoBehaviour {

	public string leveltoLoad;

	public float delay = 3f;
	private float lastTime;

	[Space]
	[Header("Player")]
	public GameObject player;

	[Space]
	[Header("Actor Template")]
	public Actor playerTemplate;
	public Actor monsterTemplate;

	private BattleWindow battleWindow;
	private Actor playerActor;
	private StatsWindow statsWindow;


	public WindowManager windowManager{
		
		get{
		//	StartCoroutine(AddPlayer());
			return GenericWindow.manager;
		}

	}

	void Start()
	{
		
	}


	public void Reset()
	{
		
		StartCoroutine (AddPlayer ());

	}

	IEnumerator AddPlayer(){
		
		yield return new WaitForEndOfFrame ();
		CreatePlayer ();

	}
	public void CreatePlayer()
	{
		playerActor = playerTemplate.Clone<Actor> ();

		playerActor.ResetHealth ();

		statsWindow = windowManager.Open ((int)Windows.StatsWindow - 1, false) as StatsWindow;
		statsWindow.target = playerActor;

		statsWindow.UpdateStats();

		if (Application.isPlaying) {
			StartBattle ();
			print ("call StartBattle");
		}
	}

	public void StartBattle()
	{
		var monsterActor = monsterTemplate.Clone<Actor> ();
		monsterActor.ResetHealth ();


		battleWindow = windowManager.Open ((int)Windows.BattleWindow - 1, false) as BattleWindow;
		battleWindow.battleOverCallback += BattleOver;
		battleWindow.StartBattle (playerActor, monsterActor);
		print ("activate StartBattle");

	}

	public void EndBattle()
	{
		battleWindow.Close ();


	}

	private void BattleOver(bool playerWin)
	{
		EndBattle ();

		if (!playerWin) {

			Destroy (player);
			playerActor = null;

		}
		var messageWindow = windowManager.Open ((int)Windows.MessageWindow - 1, false) as MessageWindow;
		messageWindow.text = "The game is over";


		if(Time.time > (lastTime + delay))
			{
				lastTime = Time.time;
		SceneManager.LoadScene (leveltoLoad);
			}
	}
}
