using UnityEngine;
using System.Collections;

public class Chihuahua : Location {
	public GameObject Hunter;
	public GUIText status;

	// Use this for initialization
	void Start () {
		locationName = "Chihuahua";
		((LocationTracker)GameObject.Find ("LocationTracker").GetComponent ("LocationTracker")).currentLocation = this;

		// spawn scalp hunters
		Vector3 initPos = transform.position;

		GameObject hunter;
		Land land = (Land) GameObject.Find ("Land").GetComponent ("Land");

		for (int i=0; i<Config.INITIAL_HUNTERS; ++i) {
			initPos.x = transform.position.x + Random.Range (-0.3f,0.4f); 
			initPos.y = transform.position.y + Random.Range (-0.6f,0.6f);
			hunter = (GameObject) Instantiate (Hunter, initPos, Quaternion.identity);
			hunter.transform.position = land.snapToGrid(hunter.transform.position);
		}
		((StatusText)status.GetComponent ("StatusText")).addText("A group of scalp hunters gather at Chihuahua.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
