using UnityEngine;
using System.Collections;


public class MouseFollow : MonoBehaviour {
	void Start () {
		GameObject Chihuahua = GameObject.Find ("Chihuahua");
		updatePosition (Chihuahua.transform.position);
	}

	void updatePosition(Vector3 newPos){
		if ((Mathf.Abs (transform.position.x - newPos.x) > Config.MOVEMENT_THRESHOLD_X)) {
			transform.position = new Vector3 (
				Mathf.MoveTowards (transform.position.x, 
			                   Mathf.Clamp (newPos.x, Config.MIN_X, Config.MAX_X), 
			                   Config.MAP_MOVEMENT_RATE * Time.deltaTime),
				transform.position.y,
				transform.position.z);
		}
		
		if ((Mathf.Abs (transform.position.y - newPos.y) > Config.MOVEMENT_THRESHOLD_Y)) {
			transform.position = new Vector3 (
				transform.position.x,
				Mathf.MoveTowards (transform.position.y, 
			                   Mathf.Clamp (newPos.y, Config.MIN_Y, Config.MAX_Y), 
			                   Config.MAP_MOVEMENT_RATE * Time.deltaTime),
				transform.position.z);
		}
	}

	void Update () {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		updatePosition (mousePosition);
	}
}
