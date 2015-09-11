using UnityEngine;
using System.Collections;

public class TPSCameraBehaviour : MonoBehaviour {

	public GameObject target;
	private Transform position;
	public float damping = 1;
	Vector3 offset;
	public float upLook = 1.0f;

	void Start() {
		offset = target.transform.position - transform.position;
		position = target.transform;
		position.Translate(Vector3.up * upLook);
	}
	
	void LateUpdate() {


		float myAngle = target.transform.eulerAngles.y - 180;
		float desiredAngle = target.transform.eulerAngles.y;

		float subAngle = Mathf.LerpAngle(myAngle, desiredAngle, damping);

		float angle = Mathf.LerpAngle(subAngle, desiredAngle, Time.deltaTime * damping);
		
		Quaternion rotation = Quaternion.Euler(0, angle, 0);
		transform.position = target.transform.position - (rotation * offset);


		transform.LookAt(target.transform);
	}

}
