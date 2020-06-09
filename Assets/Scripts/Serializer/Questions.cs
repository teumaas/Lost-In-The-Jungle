using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Questions
{
	public string _id;
	public string name;
	public string pin;

	public static Questions CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<Questions>(jsonString);
	}
}
