using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText scoreGT;
	public int FruitPoints;

	// Use this for initialization
	void Start () {

		GameObject scoreGO = GameObject.Find ("ScoreCounter");

		scoreGT = scoreGO.GetComponent<GUIText> ();

		scoreGT.text = "0";

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos2D = Input.mousePosition;

		mousePos2D.z = -Camera.main.transform.position.z;

		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D); 

		Vector3 pos = this.transform.position;

		pos.x = mousePos3D.x;

		this.transform.position = pos;
	}

	void OnCollisionEnter(Collision Coll){
	
		GameObject collidedWith = Coll.gameObject;

		if (collidedWith.tag == "Apple") {
		
			Destroy (collidedWith);
		}

		int score = int.Parse (scoreGT.text);

		score += FruitPoints;

		scoreGT.text = score.ToString ();

		if (score > HighScore.score) {
			HighScore.score = score;
		}
	}
}
