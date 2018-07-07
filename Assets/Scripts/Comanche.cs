using UnityEngine;
using System.Collections;

public class Comanche : Indian {

	// Use this for initialization
	override public void Start () {
		base.Start ();
		destination = Config.COMANCHE_LOC_2;
		health = 100;
		damage = Config.KNIFE_DAMAGE;
		horse = true;
		personNameCap = "A Comanche warrior";
		personName = "a Comanche warrior";
	}

	
	override public Vector3 getLoc1(){
		return Config.COMANCHE_LOC_1;
	}
	override public Vector3 getLoc2(){
		return Config.COMANCHE_LOC_2;
	}
	override public Vector3 getLoc3(){
		return Config.COMANCHE_LOC_3;
	}


}
