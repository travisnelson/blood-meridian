using UnityEngine;
using System.Collections;

public class Hunter : Person {
	public GameObject Blood1;
	public GameObject Blood2;
	public GameObject Blood3;
	public GameObject Corpse;

	// Use this for initialization
	override public void Start () {
		base.Start ();
		realPos = transform.position;
		personNameCap = "A scalp hunter";
		personName = "a scalp hunter";
		health = 100;
		damage = Config.BAREHAND_DAMAGE;
	}
	
	// Update is called once per frame
	void Update () {
		if(dead)
			return;

		// chase mouse pointer
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Person victim=null;
		StatusText status = (StatusText) GameObject.Find ("StatusText").GetComponent ("StatusText");

		if((victim=walkTowards (mousePosition))!=null){
			if((victim as Hunter)==null && victim.dead!=true){
				fight (victim);
			} else {
				fidget();
			}
		}

		// sell scalps, upgrade, heal
		LocationTracker location = (LocationTracker)GameObject.Find ("LocationTracker").GetComponent ("LocationTracker");

		if(location.currentLocation!=null && location.currentLocation.locationName == "Chihuahua"){
			if(horse==false && scalps > Config.HORSE_COST){
				scalps -= Config.HORSE_COST;
				horse=true;
				status.addText (personNameCap+" buys a horse.", true);
			}

			if(damage == Config.BAREHAND_DAMAGE && scalps >= Config.KNIFE_COST){
				scalps -= Config.KNIFE_COST;
				damage = Config.KNIFE_DAMAGE;
				status.addText (personNameCap+" buys a large knife.", true);
			} else if (damage == Config.KNIFE_DAMAGE && scalps >= Config.PISTOL_COST){
				scalps -= Config.PISTOL_COST;
				damage = Config.PISTOL_DAMAGE;
				status.addText (personNameCap+" buys a "+(Random.Range (0,2)==0?"Colt Paterson pistol":"Whitneyville Colt pistol")+".", true);
			} else if (damage == Config.PISTOL_DAMAGE && scalps >= Config.RIFLE_COST){
				scalps -= Config.RIFLE_COST;
				damage = Config.RIFLE_DAMAGE;
				status.addText (personNameCap+" buys a Wesson rifle.", true);
			}

			if(health < Config.HUNTER_MAX_HEALTH-10 && scalps > 0){
				health = Config.HUNTER_MAX_HEALTH;
				status.addText (personNameCap+" eats, drinks and feels better.", true);
				--scalps;
			}
		}
	}

	void throwBlood(Person p){
		Vector3 loc = p.transform.position;

		switch(Random.Range (0,8)){
		case 0:
			loc.x -= Config.TILE_WIDTH;
			loc.y -= Config.TILE_HEIGHT;
			break;
		case 1:
			loc.x += Config.TILE_WIDTH;
			loc.y -= Config.TILE_HEIGHT;
			break;
		case 2:
			loc.x += Config.TILE_WIDTH;
			loc.y += Config.TILE_HEIGHT;
			break;
		case 3:
			loc.y -= Config.TILE_HEIGHT;
			break;
		case 4:
			loc.x -= Config.TILE_WIDTH;
			break;
		case 5:
			loc.x -= Config.TILE_WIDTH;
			loc.y += Config.TILE_HEIGHT;
			break;
		case 6:
			loc.x += Config.TILE_WIDTH;
			break;
		case 7:
			loc.y += Config.TILE_HEIGHT;
			break;
		}

		GameObject blood=null;
		switch(Random.Range (0,3)){
		case 0:
			blood=(GameObject)Instantiate (Blood1);
			break;
		case 1:
			blood=(GameObject)Instantiate (Blood2);
			break;
		case 2:
			blood=(GameObject)Instantiate (Blood3);
			break;
		}

		blood.transform.position = loc;
	}

	public void fight(Person victim){
		// need to add fight code
		// blood, scalps, health, etc.
		StatusText status = (StatusText) GameObject.Find ("StatusText").GetComponent ("StatusText");

		throwBlood(victim);

		victim.health -= (int)(damage * (1 + Random.Range (-Config.DAMAGE_VARIANCE, Config.DAMAGE_VARIANCE)));

		if(victim.health <= 0){
			//throwBlood(victim);
			scalps += victim.scalps + 1;
			status.addText(personNameCap + " kills and scalps "+ victim.personName + ".");
			victim.dead = true;
			GameObject corpse = (GameObject)Instantiate (Corpse);
			corpse.transform.position = new Vector3(victim.transform.position.x, victim.transform.position.y, victim.transform.position.z);
			Destroy (victim.gameObject);
		} else {
			throwBlood(this);

			health -= (int)(victim.damage * (1 + Random.Range (-Config.DAMAGE_VARIANCE, Config.DAMAGE_VARIANCE)));

			if(health <= 0){
				//throwBlood(this);
			
				status.addText(victim.personNameCap + " kills " + personName + ".");
				dead = true;
				scalps = 0;
				//Destroy (this);
			}
		}
	}

}
