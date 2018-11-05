using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNewArea : MonoBehaviour {

	public string LevelToLoad;

	public string exitSpawnPoint;

	public GameObject enemy;

	private PlayerMovement player;

	private BattleWindow battleWindow;

	private bool isAlive = true;

	void Start()
	{
		player = FindObjectOfType<PlayerMovement> ();
		Debug.Log (isAlive);
		if (isAlive == false) {
			Debug.Log (isAlive);
			Destroy (enemy);
		}

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.name == "Player") 
		{
			Destroy (enemy);
			SceneManager.LoadScene (LevelToLoad);
			player.startPoint = exitSpawnPoint;

			isAlive = false;
			Debug.Log (isAlive);
			//print ("hi");
		}

	}

	void Update()
	{
		/*if (LevelToLoad == "Battle") {
			StartBattle ();

		}*/
	}

	public WindowManager windowManager{
		get{
			return GenericWindow.manager;
		}

	}
	public void StartBattle(){
		battleWindow = windowManager.Open ((int)Windows.BattleWindow - 1, false) as BattleWindow;
		battleWindow.StartBattle (null,null);
		//TogglePlayerMovement (false);
	}

	public void EndBattle(){
		battleWindow.Close ();
		//TogglePlayerMovement (true);
	}

}
