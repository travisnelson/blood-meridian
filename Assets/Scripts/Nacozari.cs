using UnityEngine;
using System.Collections;

public class Nacozari : Location {
	public GameObject Gileno;
	
	// Use this for initialization
	void Start () {
		locationName = "Nacozari";
		
		// spawn civilians
		Vector3 initPos = transform.position;
		
		GameObject indian;
		Land land = (Land) GameObject.Find ("Land").GetComponent ("Land");
		
		int maxCitizen = (int)(Config.NACOZARI_MAX_CITIZENS * (1 + Random.Range (-Config.POPULATION_VARIANCE, Config.POPULATION_VARIANCE)));
		for (int i=0; i<maxCitizen; ++i) {
			initPos.x = transform.position.x + Random.Range (-0.1f,0.1f); 
			initPos.y = transform.position.y + Random.Range (-0.1f,0.1f);
			indian = (GameObject) Instantiate (Gileno, initPos, Quaternion.identity);
			((Gileno)indian.GetComponent ("Gileno")).homeTown = gameObject;
			indian.transform.position = land.snapToGrid(indian.transform.position);
		}	
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
