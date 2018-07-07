using UnityEngine;
using System.Collections;

public class Apache : Indian {

	// Use this for initialization
	override public void Start () {
		base.Start ();
		personNameCap = "An Apache raider";
		personName = "an Apache raider";
		destination = Config.INDIAN_LOC_1;
		health = 25;
		damage = Config.INDIAN_SPEAR_DAMAGE;

	}
}
