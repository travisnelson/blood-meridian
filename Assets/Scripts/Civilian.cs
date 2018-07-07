using UnityEngine;
using System.Collections;

public class Civilian : Person {

	// Use this for initialization
	override public void Start () {
		base.Start ();
		health = 15;
		damage = Config.BAREHAND_DAMAGE;
		realPos = transform.position;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if(dead)
			return;
		
		if(Random.Range (0,100) < Config.CIVILIAN_FIDGET_SPEED){
			fidget();
		} else if(Random.Range (0,100) < Config.CIVILIAN_TRAVEL_SPEED){
			walkTowards(homeTown.transform.position);
		}

	}
}
