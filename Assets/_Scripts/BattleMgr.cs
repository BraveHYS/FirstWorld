using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
	/// <summary>
	/// 音符列数
	/// </summary>
	public int Col = 5;

	private List<NoteMgr> noteMgrs = new List<NoteMgr>();


	private void Start()
	{
		NoteHelper.Init();

		InitNoteMgrs();
	}

	/// <summary>
	/// NoteMgr初始化
	/// </summary>
	void InitNoteMgrs()
	{
		Vector3 pos = transform.position;

		for (int i = 0; i < Col; i++) {
			noteMgrs.Add(new NoteMgr(pos + new Vector3(101*i,0,0)));
		}
	}

	private int len;
	private void Update()
	{
		len = noteMgrs.Count;
		for (int i = 0; i < len; i++)
		{
			noteMgrs[i].Update();
		}
	}
}

/// <summary>
/// 音符帮助类
/// </summary>
public class NoteHelper
{
	private static Dictionary<NoteType, string> dic = new Dictionary<NoteType, string>();
	private static Dictionary<NoteType, GameObject> Pool = new Dictionary<NoteType, GameObject>(); 

	public static void Init()
	{
		dic.Add(NoteType.A, "Note_A");
		dic.Add(NoteType.S, "Note_S");
		dic.Add(NoteType.J, "Note_J");
		dic.Add(NoteType.K, "Note_K");
	}

	/// <summary>
	/// 根据音符类型获取Prefab名字
	/// </summary>
	public static string GetName(NoteType type)
	{
		if (dic.ContainsKey(type))
		{
			return dic[type];
		}
		else
		{
			MyLog.LogError("Dictionary Doesn't Contains Key : " + type);
			return null;
		}
	}

	/// <summary>
	/// 根据音符类型获取Prefab物体
	/// </summary>
	public static GameObject GetPrefab(NoteType type)
	{
		GameObject go;
		if (Pool.ContainsKey(type))
		{
			go = Pool[type];
		}
		else
		{
			go = Resources.Load<GameObject>(GetName(type));
			if (go != null)
			{
				Pool.Add(type, go);
			}
			else
			{
				MyLog.LogError("Load Resources Error : " + type);
			}
		}

		return go;
	}
}
