using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//reference: https://www.youtube.com/watch?v=Hj7AZkyojdo&index=2&t=0s&list=PLboXykqtm8dynMisqs4_oKvAIZedixvtf

public class Inventory : MonoBehaviour {

	private const int SLOTS = 9;

	private List<IInventoryItem> mItems = new List<IInventoryItem>();

	public event EventHandler<InventoryEventArgs> ItemAdded;

	public void AddItem(IInventoryItem item)
	{
		if (mItems.Count < SLOTS) {
			Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D> ();
			print ("hello its me");
			if (collider.enabled) 
			{
				print ("boo ya");
				collider.enabled = false;

				mItems.Add (item);

				item.OnPickup ();

			}

			if (ItemAdded != null) 
			{
				ItemAdded (this, new InventoryEventArgs (item));

			}


		}


	}
}
