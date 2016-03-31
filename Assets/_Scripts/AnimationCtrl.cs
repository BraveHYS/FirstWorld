using UnityEngine;
using System.Collections;

public class AnimationCtrl : MonoBehaviour {

	private Animation Animation;
	public float moveSpeed;
	public float runNum;
	private float ace = 2f;
	private void Start() {
		Animation = GetComponent<Animation>();
		Animation["jump"].speed = 1;
		Animation["run"].speed = 1;
		Animation["walk"].speed = 1;
	}

	Vector3 velocity;
	private float forward;
	private float right;
	public float maxSpeed;

	void Update() {
		if (Input.GetKey(KeyCode.W))
        {
			forward += ace * Time.deltaTime;
	        if (forward > maxSpeed)
	        {
		        forward = maxSpeed;
	        }
		} 
		else if (Input.GetKeyUp(KeyCode.W))
        {
			forward = 0;
		}

		if (Input.GetKey(KeyCode.S)) {
			forward -= ace * Time.deltaTime;
			if (forward < -maxSpeed) {
				forward = -maxSpeed;
			}
		} else if (Input.GetKeyUp(KeyCode.S)) {
			forward = 0;
		}

		if (Input.GetKey(KeyCode.A)) {
			right -= ace * Time.deltaTime;
			if (right < -maxSpeed) {
				right = -maxSpeed;
			}
		} else if (Input.GetKeyUp(KeyCode.A)) {
			right = 0;
		}

		if (Input.GetKey(KeyCode.D)) {
			right += ace * Time.deltaTime;
			if (right > maxSpeed) {
				right = maxSpeed;
			}
		} else if (Input.GetKeyUp(KeyCode.D)) {
			right = 0;
		}

		velocity = new Vector3(right,0,forward);
		Debug.Log(velocity);

		if (velocity.magnitude < runNum && velocity.magnitude > 0)
		{
			Animation.Play("walk");
		} else if (velocity.magnitude >= runNum)
		{
			Animation.Play("run");
		}
		else if(velocity.magnitude <= 0)
		{
			Animation.Play("idle");
		}

		transform.Translate(velocity * Time.deltaTime);

//		if (Input.GetKey(KeyCode.S))//只要S键不松开，速度就增加；
//        {
//			if (moveSpeed < runNum) {
//				moveSpeed = moveSpeed + ace * Time.deltaTime;
//			}
//			transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.World);
//
//			if (moveSpeed > runNum)//速度大于runnume就播放run动画
//            {
//				Animation.CrossFade("run");
//			} else
//				Animation.CrossFade("walk");
//		} else if (Input.GetKeyUp(KeyCode.S))//一旦监听到S键被松开，动画则播idle
//        {
//			moveSpeed = 0;
//			Animation.CrossFade("idle");
//		}
//
//		if (Input.GetKey(KeyCode.A))//只要A键不松开，速度就增加；
//        {
//			if (moveSpeed < runNum) {
//				moveSpeed = moveSpeed + ace * Time.deltaTime;
//			}
//			transform.Translate(moveSpeed * Time.deltaTime, 0, 0, Space.World);
//			if (moveSpeed > runNum)//速度大于runnume就播放run动画
//            {
//				Animation.CrossFade("run");
//			} else
//				Animation.CrossFade("walk");
//		} else if (Input.GetKeyUp(KeyCode.A))//一旦监听到A键被松开，动画则播idle
//        {
//			moveSpeed = 0;
//			Animation.CrossFade("idle");
//		}
//
//		if (Input.GetKey(KeyCode.D))//只要A键不松开，速度就增加；
//        {
//			if (moveSpeed < runNum) {
//				moveSpeed = moveSpeed + ace * Time.deltaTime;
//			}
//			transform.Translate(-(moveSpeed * Time.deltaTime), 0, 0, Space.World);
//			if (moveSpeed > runNum)//速度大于runnume就播放run动画
//            {
//				Animation.CrossFade("run");
//			} else
//				Animation.CrossFade("walk");
//		} else if (Input.GetKeyUp(KeyCode.D))//一旦监听到D键被松开，动画则播idle
//        {
//			moveSpeed = 0;
//			Animation.CrossFade("idle");
//		}
//
//		if (Input.GetKey(KeyCode.Space)) {
//
//			Animation.CrossFade("jump");
//			moveSpeed = 0;//保证跳完后继续的是idle动画
//		} else
//			Animation.CrossFade("idle");
	}
}

