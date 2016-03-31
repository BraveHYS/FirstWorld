using System;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;


public class StudentManager : MonoBehaviour {
	private Student student;

	void Awake() {
		student = new Student(111, "Man", 20);
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log(student.Name + " , " + student.ID + " , " + student.Age);

			student.SetAge(22);

			Debug.Log(student.Name + " , " + student.ID + " , " + student.Age);

			student.SetGender(false);

			Debug.Log(student.GetName());
		}
	}
}

public class Student 
{
	/// <summary>
	/// 学号
	/// </summary>
	public int ID;

	/// <summary>
	/// 姓名
	/// </summary>
	public string Name;

	/// <summary>
	/// 年龄
	/// </summary>
	public int Age;

	/// <summary>
	/// 性别
	/// </summary>
	private bool isMan;

	public Student()
	{
		
	}

	public Student(int id, string name, int age)
	{
		this.ID = id;
		this.Name = name;
		this.Age = age;
	}


	/// <summary>
	/// 设置年龄
	/// </summary>
	/// <param name="age"></param>
	public void SetAge(int age)
	{
		this.Age = age;
	}

	public void SetGender(bool gender)
	{
		this.isMan = gender;
	}


	/// <summary>
	/// 获取名字
	/// </summary>
	/// <returns></returns>
	public string GetName()
	{
		string str;
		if (isMan)
		{
			str = Name;
		}
		else
		{
			str = "I dont tell you";
		}

		return str;
	}
}

