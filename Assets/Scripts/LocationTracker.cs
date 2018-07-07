using UnityEngine;
using System.Collections;

public class LocationTracker : MonoBehaviour {
	public Location currentLocation=null;
	private int notFound = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Hunter[] hunters = FindObjectsOfType (typeof(Hunter)) as Hunter[];
		Location[] locations = FindObjectsOfType (typeof(Location)) as Location[];
		StatusText status = (StatusText) GameObject.Find ("StatusText").GetComponent ("StatusText");

		foreach (Location l in locations){
			l.hunterCount=0;
		}

		int hCount = 0;
		foreach (Hunter h in hunters){
			if(!h.dead)
				hCount++;
		}

		bool found = false;
		foreach (Hunter h in hunters) {
			if(h.dead)
				continue;
			
			foreach (Location l in locations){
				if(!(h.gameObject.renderer.bounds.min.x > l.gameObject.renderer.bounds.max.x ||
				   h.gameObject.renderer.bounds.max.x < l.gameObject.renderer.bounds.min.x ||
				   h.gameObject.renderer.bounds.min.y > l.gameObject.renderer.bounds.max.y ||
				   h.gameObject.renderer.bounds.max.y < l.gameObject.renderer.bounds.min.y)){
					l.hunterCount++;
					if(l.hunterCount > hCount/2){
						found = true;
						if(currentLocation != l){
							currentLocation=l;
							status.addText ("The gang enters "+l.locationName+".");
							notFound=0;
							break;
						}
					}
				}
			}		
		}

		if(!found){
			notFound++;		
			if(notFound > Config.EXIT_LOCATION_THRESHOLD){
				currentLocation=null;
				notFound=0;
			}
		}
	}
}
