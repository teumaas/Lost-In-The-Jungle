using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Serializer;

[Serializable]
public class Question
{
	public Answer[] answers;
	public string _id;
	public string question;
	public string gameID;
	public int level;

	public static Question CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<Question>(jsonString);
	}
}
