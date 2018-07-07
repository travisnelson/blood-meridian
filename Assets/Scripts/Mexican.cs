using UnityEngine;
using System.Collections;

public class Mexican : Civilian {
	// Use this for initialization
	override public void Start () {
		base.Start ();
		personNameCap = "A Mexican villager";
		personName = "a Mexican villager";
	}
	
	// Update is called once per frame
	override public void Update () {
		base.Update ();
	}
}
