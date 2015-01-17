using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private int count;
	public Text countText;
	public Text winText;

	void Start(){
		count = 0;
		SetCountText();
		winText.gameObject.SetActive (false);
	}

	void FixedUpdate () {
		float moveHorizontal;
		float moveVertical;
		float d_speed = speed;

		if (Input.acceleration.x == 0 && Input.acceleration.y == 0) {
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		} else {
			moveHorizontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y;
			d_speed *= 3;
		}


		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * d_speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
			if(count >= 13){
				winText.gameObject.SetActive (true);
			}
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
	}
}
