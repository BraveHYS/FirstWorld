using UnityEngine;
using System.Collections;

public class InputCtrl : MonoBehaviour
{
	Vector3 velocity = new Vector3();

	public float speed;

	public float y;

	public float jumpSpeed;

	public float gravity;

	private Vector3 vec;

	private void Update()
	{
		velocity = Vector3.zero;
//		if (Input.GetKey(KeyCode.W))
//		{
//			velocity += Vector3.forward;
//		}
//
//		if (Input.GetKey(KeyCode.S)) {
//			velocity -= Vector3.forward;
//		}
//		if (Input.GetKey(KeyCode.A)) {
//			velocity += Vector3.left;
//		}
//		if (Input.GetKey(KeyCode.D)) {
//			velocity -= Vector3.left;
//		}
//
		if (Input.GetKeyDown(KeyCode.Space))
		{
			y = jumpSpeed;
		}
		
		y -= gravity*Time.deltaTime;

//		velocity = new Vector3(velocity.x, y, velocity.z);
		velocity = new Vector3(Input.GetAxis("Horizontal"), y, Input.GetAxis("Vertical"));


		vec += velocity*Time.deltaTime*speed;

		if (vec.y < 0)
		{
			vec.y = 0;
		}

		transform.position = vec;
	}
}
