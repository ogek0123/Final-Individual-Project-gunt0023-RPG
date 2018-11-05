using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : ScriptableObject {

	public new string name;
	public int health;
	public int maxHealth;
	public int gold;
	public Vector2 attackRange = Vector2.one;
	private int counter = 0;
	public bool alive{
		get{
			return health > 0;
		}
	}

	public void DecreaseHealth(int value)
	{
		counter++;
		health = Mathf.Max (health - value, 0);
	}

	public void ResetHealth(){
		if (counter == 0) {
			health = maxHealth;
		}
	}

	public void IncreaseGold(int value)
	{
		gold += value;

	}

	public T Clone<T>() where T : Actor{

		var clone = ScriptableObject.CreateInstance<T> ();

		clone.name = name;
		clone.health = health;
		clone.maxHealth = maxHealth;
		clone.gold = gold;
		clone.attackRange = attackRange;

		return clone;
	}
}
