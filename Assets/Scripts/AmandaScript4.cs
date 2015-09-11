using UnityEngine;
using System.Collections;
public class AmandaScript4 : MonoBehaviour {
	public float speed=1;
	public Rigidbody robot;
	public Transform target;
	public Transform targetOriginal;
	public GameObject mytarget;
	public Vector3 targetPos;
	public bool flag;
	public GameObject player;

	public GameObject myUI;

	// Update is called once per frame
	void Start(){
		robot = gameObject.GetComponent<Rigidbody>();
		target = GameObject.FindGameObjectWithTag("plane7").transform;
		targetOriginal = GameObject.FindGameObjectWithTag("plane8").transform;
		flag = false;
	}
	void Update () {
		Movement3D movement = player.GetComponent<Movement3D>();
		transform.Rotate (new Vector3 (0, -20, 0) * Time.deltaTime);
		if (flag==false) {
			
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			if(transform.position==target.position){
				flag = true;
			}
			
		}
		if (flag == true) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, targetOriginal.position, step);
			if(transform.position==targetOriginal.position){
				flag = false;
			}
		}
		Vector3 directionToTarget = robot.transform.position - GameObject.FindWithTag("Player").transform.position;//
		float distance = directionToTarget.magnitude;
		float angle = 10;
		if( Vector3.Angle (robot.transform.forward, GameObject.FindWithTag ("Player").transform.position - robot.transform.position) < angle && distance < 30 && !movement.invisible) //
		{
			Debug.Log("Done");
			myUI.SetActive(true);	
		}
	}
}
	
