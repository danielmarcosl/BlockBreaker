using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MovePaddle ();
	}

	void MovePaddle () {
		float mousePositionInBlocks = ((Input.mousePosition.x / Screen.width) * 16) - 8;

		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);

		paddlePos.x = Mathf.Clamp (mousePositionInBlocks, -7.5f, 7.5f);
		this.transform.position = paddlePos;
	}
}
