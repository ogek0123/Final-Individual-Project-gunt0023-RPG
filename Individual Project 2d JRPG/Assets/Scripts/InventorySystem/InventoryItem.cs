using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//reference: https://www.youtube.com/watch?v=Hj7AZkyojdo&index=2&t=0s&list=PLboXykqtm8dynMisqs4_oKvAIZedixvtf

public interface IInventoryItem {

	string Name { get; }

	Sprite Image { get; }

	void OnPickup();
}

public class InventoryEventArgs : EventArgs
{
	public InventoryEventArgs(IInventoryItem item)
	{
		Item = item;

	}

	public IInventoryItem Item;
}
