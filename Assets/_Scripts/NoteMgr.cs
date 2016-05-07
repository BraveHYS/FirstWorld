using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using UnityEngine;

public class NoteMgr
{
	/// <summary>
	/// 音符出生位置
	/// </summary>
	private Vector3 originPos;

	/// <summary>
	/// 随机数（数值越大，音符生成频率越小）
	/// </summary>
	private int random = 3000;

	private List<Note> notes = new List<Note>();

	public NoteMgr(Vector3 pos)
	{
		originPos = pos;
	}

	public void Update()
	{
		GenerateNode();

		Check();
	}

	/// <summary>
	/// 检查当前生成音符状态
	/// </summary>
	private int len;
	private List<Note> excuteList = new List<Note>();
	void Check() {
		excuteList.AddRange(notes);
		len = excuteList.Count;
		for (int i = 0; i < len; i++) {
			Note temp = excuteList[i];
			NoteState tempEnum = temp.MoveDown();
			switch (tempEnum) {
				case NoteState.Catch:
					MyLog.Log("Catch Successfully");
					notes.Remove(temp);
					break;
				case NoteState.Miss:
					MyLog.Log("Miss");
					break;
				case NoteState.Destroy:
					notes.Remove(temp);
					break;
			}
		}

		excuteList.Clear();
	}

	/// <summary>
	/// 音符生成
	/// </summary>
	/// <returns></returns>
	void GenerateNode()
	{
		int seed = Random.Range(0, random);
		if (seed > 5)
		{
			seed = seed % (random - 5);

			switch (seed)
			{
				case 1:
					notes.Add(new Note(NoteType.A, originPos));
					break;
				case 2:
					notes.Add(new Note(NoteType.S, originPos));
					break;
				case 3:
					notes.Add(new Note(NoteType.J, originPos));
					break;
				case 4:
					notes.Add(new Note(NoteType.K, originPos));
					break;
			}
		}
	}
}
