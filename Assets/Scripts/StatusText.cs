using UnityEngine;
using System.Collections;

public class StatusText : MonoBehaviour {
	string[] lines;
	int[] repeats;

	// Use this for initialization
	void Start () {
		lines = new string[4];
		repeats = new int[4];
		repeats[0]=0;
		repeats[1]=0;
		repeats[2]=0;
		repeats[3]=0;
	}

	public void addText(string txt, bool merge=false){
		if(lines[0] == txt){
			repeats[0]++;
		} else if(merge && lines[1] == txt){
			repeats[1]++;
		} else if(merge && lines[2] == txt){
			repeats[2]++;
		} else if(merge && lines[3] == txt){
			repeats[3]++;
		} else {
			lines[3]=lines[2];
			lines[2]=lines[1];
			lines[1]=lines[0];
			lines[0]=txt;

			repeats[3]=repeats[2];
			repeats[2]=repeats[1];
			repeats[1]=repeats[0];
			repeats[0]=1;
		}

		int scalps = 0;

		Hunter[] hunters = FindObjectsOfType (typeof(Hunter)) as Hunter[];
		foreach (Hunter h in hunters) {
			scalps += h.scalps;
		}

		guiText.text = 
			lines [0] + (repeats [0] > 1 ? " x" + repeats [0] : "") + "\n" +
						lines [1] + (repeats [1] > 1 ? " x" + repeats [1] : "") + "\n" +
						lines [2] + (repeats [2] > 1 ? " x" + repeats [2] : "") + "\n" +
						lines [3] + (repeats [3] > 1 ? " x" + repeats [3] : "") + "\n" +
						scalps + " scalps";
	}


	// Update is called once per frame
	void Update () {
	
	}
}
