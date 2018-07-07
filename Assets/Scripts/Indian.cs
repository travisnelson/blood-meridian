using UnityEngine;
using System.Collections;

public class Indian : Person {
	public Vector3 destination;
	public bool roving = false;

	// Use this for initialization
	override public void Start () {
		base.Start ();
		realPos = transform.position;
		personNameCap = "An indian";
		personName = "an indian";
		health = 50;
		damage = Config.KNIFE_DAMAGE;
	}

	public virtual Vector3 getLoc1(){
		return Config.INDIAN_LOC_1;
	}
	public virtual Vector3 getLoc2(){
		return Config.INDIAN_LOC_2;
	}
	public virtual Vector3 getLoc3(){
		return Config.INDIAN_LOC_3;
	}

	// Update is called once per frame
	void Update () {
		Person victim=null;
		//StatusText status = (StatusText) GameObject.Find ("StatusText").GetComponent ("StatusText");

		if(Random.Range (0,100) < Config.INDIAN_FIDGET_SPEED){
			fidget();
			return;
		}

		Vector3 tmpDestination=new Vector3();

		Hunter[] hunters = FindObjectsOfType (typeof(Hunter)) as Hunter[];
		bool found = false;
		foreach (Hunter h in hunters) {
			if(!h.dead && Vector3.Distance (h.transform.position, transform.position) < 1){
				tmpDestination = h.transform.position;
				found=true;
				break;
			}
		}

		if(!found){
			tmpDestination = new Vector3 (destination.x + Random.Range (-1f, 1f),
		                               destination.y + Random.Range (-1f, 1f),
		                               destination.z);
		}

		if((found || roving) && (victim=walkTowards (tmpDestination))!=null){
			if((victim as Hunter)!=null && victim.dead!=true){
				(victim as Hunter).fight (this);
			} else {
				fidget();
			}
		} else if(Vector3.Distance(destination, transform.position) < Random.Range (0f,1f)){
			if(destination == getLoc1 ()){
				destination = getLoc2 ();
			} else if(destination == getLoc2 ()){
				destination = getLoc3 ();
			} else if(destination == getLoc3()){
				destination = getLoc1 ();
			}
		}
	}
}
