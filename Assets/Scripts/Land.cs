using UnityEngine;
using System.Collections;

public class Land : MonoBehaviour {
	public GameObject Apache;
	public GameObject Comanche;

	// Use this for initialization
	void Start () {
		Vector3 initPos = transform.position;
		
		GameObject indian;

		// small Apache raiding party near Chihuahua
		for(int i=0; i<5; ++i){
			initPos.x = transform.position.x + Random.Range (7f,7.5f); 
			initPos.y = transform.position.y + Random.Range (-3.5f,-4f);
			initPos.z = Config.ACTOR_Z_DEPTH;
			indian = (GameObject) Instantiate (Apache, initPos, Quaternion.identity);
			indian.transform.position = snapToGrid(indian.transform.position);
		}

		// travelling horde of Apaches
		for (int i=0; i<35; ++i) {
			initPos.x = transform.position.x + Random.Range (-3f,-2.5f); 
			initPos.y = transform.position.y + Random.Range (1f,1.5f);
			initPos.z = Config.ACTOR_Z_DEPTH;
			indian = (GameObject) Instantiate (Apache, initPos, Quaternion.identity);
			indian.transform.position = snapToGrid(indian.transform.position);
			((Apache)indian.GetComponent("Apache")).roving = true;
		}

		// comanche horse
		for (int i=0;i<35;++i){
			initPos.x = transform.position.x + Random.Range (-6.5f,-6.9f); 
			initPos.y = transform.position.y + Random.Range (5.56f,5.96f);
			initPos.z = Config.ACTOR_Z_DEPTH;
			indian = (GameObject) Instantiate (Comanche, initPos, Quaternion.identity);
			indian.transform.position = snapToGrid(indian.transform.position);
			((Comanche)indian.GetComponent("Comanche")).roving = true;
		}

	}

	public Vector3 snapToGrid(Vector3 o) {
		float x = renderer.bounds.min.x + Config.TILE_WIDTH / 2;
		float y = renderer.bounds.max.y - Config.TILE_HEIGHT / 2;

		while ((x+Config.TILE_WIDTH) < o.x) {
			x += Config.TILE_WIDTH;
		}
		if((o.x - x) > Config.TILE_WIDTH/2){
			x += Config.TILE_WIDTH;
		}

		while ((y-Config.TILE_HEIGHT) > o.y) {
			y -= Config.TILE_HEIGHT;
		}
		if((y - o.y) > Config.TILE_HEIGHT/2){
			y -= Config.TILE_HEIGHT;
		}

		return new Vector3 (x, y, o.z);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
