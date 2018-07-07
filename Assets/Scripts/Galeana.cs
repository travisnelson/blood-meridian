using UnityEngine;
using System.Collections;

public class Galeana : Location {
	public GameObject Mexican;

	// Use this for initialization
	void Start () {
		locationName = "Galeana";
		
		// spawn civilians
		Vector3 initPos = transform.position;
		
		GameObject mexican;
		Land land = (Land) GameObject.Find ("Land").GetComponent ("Land");
		
		for (int i=0; i<Config.GALEANA_MAX_CITIZENS * (1 + Random.Range(-Config.POPULATION_VARIANCE,Config.POPULATION_VARIANCE)); ++i) {
			initPos.x = transform.position.x + Random.Range (-0.1f,0.1f); 
			initPos.y = transform.position.y + Random.Range (-0.1f,0.1f);
			mexican = (GameObject) Instantiate (Mexican, initPos, Quaternion.identity);
			((Mexican)mexican.GetComponent ("Mexican")).homeTown = gameObject;
			mexican.transform.position = land.snapToGrid(mexican.transform.position);
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
