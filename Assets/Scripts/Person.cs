using UnityEngine;
using System.Collections;

public abstract class Person : MonoBehaviour {
	protected Vector3 realPos;
	public GameObject homeTown; 
	public string personNameCap = "A person";
	public string personName = "a person";
	public int scalps=0;
	public int health=10;
	public int damage=1;
	public bool dead = false;
	public bool horse = false;

	public virtual void Start() {
		realPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}

	public float getMovementRate(){
		if(horse){
			return Config.HUNTER_MOVEMENT_RATE_HORSE;
		} else {
			return Config.HUNTER_MOVEMENT_RATE_WALKING;
		}
	}

	public Person walkTowards(Vector3 pos){
		Land land = (Land) GameObject.Find ("Land").GetComponent ("Land");

		Vector3 newPos = new Vector3 (
			Mathf.MoveTowards (realPos.x, 
		                   Mathf.Clamp (pos.x, land.renderer.bounds.min.x, land.renderer.bounds.max.x),
		                   getMovementRate () * Time.deltaTime),
			Mathf.MoveTowards (realPos.y,
		                   Mathf.Clamp (pos.y, land.renderer.bounds.min.y, land.renderer.bounds.max.y),
		                   getMovementRate () * Time.deltaTime),
			transform.position.z);

		Vector3 snappedPos = land.snapToGrid (newPos);

		Person victim = collision (snappedPos);
		if(victim!=null){
			return victim;
		}

		realPos = newPos;
		transform.position = snappedPos;

		return null;
	}

	public Person collision(Vector3 pos){
		Person[] persons = FindObjectsOfType (typeof(Person)) as Person[];
		foreach (Person h in persons) {
			if(h != this && h.transform.position == pos && !h.dead){
				return h;
			}
		}
		return null;
	}

	// move a random direction, sometimes, without colliding
	public void fidget() {
		Vector3 pos;
		
		switch(Random.Range (0,4+Config.FIDGET_SPEED_INVERSE)){
		case 0:
			pos = transform.position;
			pos.x += Config.TILE_WIDTH;
			pos.y += Config.TILE_HEIGHT;
			if(collision (pos)==null){
				realPos = pos;
				transform.position = pos;
				break;
			}
			goto case 1;
		case 1:
			pos = transform.position;
			pos.x -= Config.TILE_WIDTH;
			pos.y += Config.TILE_HEIGHT;
			if(collision (pos)==null){
				realPos = pos;
				transform.position = pos;
				break;
			}
			goto case 2;
		case 2:
			pos = transform.position;
			pos.x -= Config.TILE_WIDTH;
			pos.y -= Config.TILE_HEIGHT;
			if(collision (pos)==null){
				realPos = pos;
				transform.position = pos;
				break;
			}
			goto case 3;
		case 3:
			pos = transform.position;
			pos.x += Config.TILE_WIDTH;
			pos.y -= Config.TILE_HEIGHT;
			if(collision (pos)==null){
				realPos = pos;
				transform.position = pos;
				break;
			}
			break;
		}
	}


}
