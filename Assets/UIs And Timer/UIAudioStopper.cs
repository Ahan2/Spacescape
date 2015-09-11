using UnityEngine;
using System.Collections;

public class UIAudioStopper : MonoBehaviour {

	private AudioSource a;
	public GameObject UI1;
	public GameObject UI2;

	// Use this for initialization
	void Start () {
		a = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(UI1.activeSelf || UI2.activeSelf) {
			a.Stop();
		}
	}
}
