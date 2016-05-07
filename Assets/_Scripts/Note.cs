using UnityEngine;

/// <summary>
/// 音符状态
/// </summary>
public enum NoteState {
	None,
	Catch,
	Miss,
	Destroy
}


/// <summary>
/// 音符类型
/// </summary>
public enum NoteType
{
	None,
	A,
	S,
	J,
	K
}

public class Note
{
	public GameObject go;
	private NoteType noteType;
	private NoteState noteEnum = NoteState.None;

	public float Speed = 100;
	public int maxY = -360;
	public int minY = -460;
	public int destroyY = -500;

	public Note(NoteType type, Vector3 pos)
	{
		Transform parent = GameObject.Find("Spawn").transform;
		noteType = type;
		this.go = GameObject.Instantiate(NoteHelper.GetPrefab(type), pos, Quaternion.identity) as GameObject;
		go.transform.SetParent(parent);
	}

	/// <summary>
	/// 向下移动
	/// </summary>
	/// <returns></returns>
	public NoteState MoveDown()
	{
		go.transform.position += -go.transform.up * Speed * Time.deltaTime;

		//到指定位置按下
		if (go.transform.localPosition.y > minY && go.transform.localPosition.y < maxY) {
			switch (noteType)
			{
				case NoteType.A:
					if (Input.GetKey(KeyCode.A))
					{
						noteEnum = NoteState.Catch;
					}
					break;
				case NoteType.S:
					if (Input.GetKey(KeyCode.S))
					{
						noteEnum = NoteState.Catch;
					}
					break;
				case NoteType.J:
					if (Input.GetKey(KeyCode.J))
					{
						noteEnum = NoteState.Catch;
					}
					break;
				case NoteType.K:
					if (Input.GetKey(KeyCode.K))
					{
						noteEnum = NoteState.Catch;
					}
					break;
			}

			if (noteEnum == NoteState.Catch)
			{
				GameObject.Destroy(go);
			}
		}
		//Miss
		else if (go.transform.localPosition.y < minY)
		{
			noteEnum = NoteState.Miss;
		}
		//Destroy
		if (go.transform.localPosition.y < destroyY)
		{
			noteEnum = NoteState.Destroy;
			GameObject.Destroy(go);
		}

		return noteEnum;
	}
}
