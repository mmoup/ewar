using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Animation> ().Play ("attack");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
