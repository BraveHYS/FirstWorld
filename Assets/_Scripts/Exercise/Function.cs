using UnityEngine;
using System.Collections;

public class Function : MonoBehaviour 
{
	#region 变量

	private int a;
	protected float b;
	public string c;
	Student student;
	private bool d;

	private const int e = 10;

	#endregion

	void Update()
	{
		string str = FuncC();
		Debug.Log(str);
	}

	#region 函数
	private void FuncA()
	{
	}

	protected Student FuncB()
	{
		return student;
	}

	public string FuncC()
	{
		return c;
	}

	public bool FuncD()
	{
		return d;
	}
	#endregion

	#region 函数重载
	public void Func()
	{
		Debug.Log("Params : ");
	}

	public void Func(int a)
	{
		Debug.Log("Params : " + a);
	}

	public void Func(int a, float b)
	{
		Debug.Log("Params : " + a + " , " + b);
	}

	public void Func(int a, float b, string c)
	{
		Debug.Log("Params : " + a + " , " + b + " , " + c);
	}

//	public string Func()
//	{
//		return c;
//	}
	#endregion



//	public T Func<T>()
//	{
//		T t = default(T);
//		return t;
//	}

//	public virtual void FuncE() { }

//	public override void FuncF() { }

//	public abstract void FunG();
}

