//using UnityEngine;
//using System.Collections;
//
//public class TransCtrl : MonoBehaviour
//{
//	private Vector3 vec = new Vector3(0,0,1);
//
//	private void Update()
//	{
//		transform.position = vec;
//		transform.Translate(Vector3.forward);

//		if (Input.GetKey(KeyCode.W))
//		{
//			transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
//		}
//
//		if (Input.GetKey(KeyCode.Q))
//		{
//			transform.Rotate(new Vector3(1,0,0));
//		}
//		transform.localScale = new Vector3(2,2,2);


using UnityEngine;
using System.Collections;

public class TransCtrl : MonoBehaviour
{
	public float dis;
	public float speed;
//	public float x;
	public float acce;

	private void Update()
	{
		Pingpong();
	}

	void Pingpong()
	{
		speed = speed + acce * Time.deltaTime;

		transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);

		if (transform.position.x <= -dis) {
			transform.position = new Vector3(-dis, 0, 0);
			//			speed = -speed;
			speed = 0;
			if (acce < 0) {
				acce = -acce;
			}
		}

		if (transform.position.x >= dis) {
			transform.position = new Vector3(dis, 0, 0);
			//			speed = -speed;
			speed = 0;
			if (acce > 0) {
				acce = -acce;
			}
		}
	}
}


//	}
//}
