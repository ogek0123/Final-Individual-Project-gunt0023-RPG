using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWindow : GenericWindow {

	private RandomMapTester tester;

	protected override void Awake()
	{
		tester = GetComponent<RandomMapTester> ();
		base.Awake ();

	}

	public override void Open()
	{
		base.Open ();
		tester.Reset ();


	}

	public override void Close()
	{
		base.Close ();
		//tester.Shutdown ();


	}
}
