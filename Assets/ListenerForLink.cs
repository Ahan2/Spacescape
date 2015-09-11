using UnityEngine;
using System.Collections;

public class ListenerForLink : MonoBehaviour {

	public GameObject link;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetLinkOn() {
		link.SetActive(true);
	}
}
