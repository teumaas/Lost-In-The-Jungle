using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level
{
	public List<Question> questions;
	public string gameID;
	public int level;

	public static Level CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<Level>(jsonString);
	}
}

