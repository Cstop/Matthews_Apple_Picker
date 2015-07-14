using UnityEngine;
using System.Collections;

public class Orange_Tree : MonoBehaviour {

	public GameObject applePrefab;
	public float speed = 1f;
	public float leftAndRightEdge = 10f;
	public float chanceToChangeDirection = 0.1f;
	public float secondsBetweenAppleDrops = 2f;
	// Use this for initialization
	void Start () {
		//Drop apples every second
		InvokeRepeating ("DropApple", 2f, secondsBetweenAppleDrops);
	}
	
	void DropApple(){
		GameObject apple = Instantiate (applePrefab) as GameObject;
		
		apple.transform.position = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		//basic movment
		Vector3 pos = transform.position;
		
		pos.x += speed * Time.deltaTime;
		
		transform.position = pos;
		//Changing Directions
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed);
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);
		}
	}
	void FixedUpdate(){
		
		if (Random.value < chanceToChangeDirection) {
			speed *= -1;
		}
		
	}
}
