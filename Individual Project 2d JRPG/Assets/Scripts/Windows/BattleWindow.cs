using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleWindow : GenericWindow 
{
	//public Image[] decorations;
	public GameObject actionsGroup;

	//public Text monsterLabel;
	public GenericBattleAction[] actions;
	[Range(0, .9f)]
	public float runOdds = .5f;
	public bool nextActionPlayer = true;

	public delegate void BattleOver(bool playerWin);
	public BattleOver battleOverCallback;

	private Actor player;
	private Actor monster;

	public string leveltoLoad;

	public override void Open()
	{
		base.Open ();


		actionsGroup.SetActive (false);
	}

	public void StartBattle(Actor target1, Actor target2)
	{
		player = target1;
		monster = target2;
		DisplayMessage ("A "+ monster.name + " has appeared");
		StartCoroutine (NextAction ());
		print ("start coroutine next action");
		//UpdateMonsterLabel ();
		//print ("hi");
	}

	public void OnAction(GenericBattleAction action, Actor target1, Actor target2)
	{

		action.Action (target1, target2);

		DisplayMessage (action.ToString());
		actionsGroup.SetActive (false);
		UpdatePlayerStats ();
		StartCoroutine (NextAction ());
		print ("bye");
	}

	public void OnPlayerAction(int id)
	{
		switch(id)
		{
		case 1:
		StartCoroutine(OnRun());
		break;
		default:
			var action = actions [id];
			OnAction (action, player, monster);

			break;
		}

		nextActionPlayer = false;
	}

	public void OnMonsterAction()
	{
		var action = actions [0];
		OnAction (action, monster, player);
		nextActionPlayer = true;

	}
	void DisplayMessage(string text)
	{
		var messageWindow = manager.Open ((int) Windows.MessageWindow - 1, false) as MessageWindow;
		messageWindow.text = text;
	}

	IEnumerator NextAction(){
		print ("nextaction is called");
		yield return new WaitForSeconds (2);
		if (!player.alive || !monster.alive) {
			StartCoroutine (OnBattleOver ());
			print ("onbattleover is called");
		}

		else
		{
			
		if (nextActionPlayer) 
			{
			actionsGroup.SetActive (true);
			OnFocus ();
			} 

		else {

			OnMonsterAction ();
			 }
		}
	}

	void UpdatePlayerStats()
	{
		((StatsWindow)manager.GetWindow((int)Windows.StatsWindow - 1)).UpdateStats();

	}

	IEnumerator OnRun()
	{
		actionsGroup.SetActive (false);

		var chance = Random.Range (0, 1f);

		if (chance < runOdds) {
			DisplayMessage ("Player has fled");
			SceneManager.LoadScene (leveltoLoad);
			yield return new WaitForSeconds (2);
			if(battleOverCallback != null)
			{
				battleOverCallback(player.alive);
			}
			//SceneManager.LoadScene (leveltoLoad);
		} else {

			DisplayMessage ("Player was unable to flee");
			StartCoroutine (NextAction ());
		}
	}

	IEnumerator OnBattleOver()
	{
		var message = (player.alive ? player.name : monster.name) + " has won the battle";

		yield return new WaitForSeconds (2);


		if(battleOverCallback != null)
		{
			battleOverCallback(player.alive);
		}

		DisplayMessage (message);

		//SceneManager.LoadScene (leveltoLoad);
	}


}
