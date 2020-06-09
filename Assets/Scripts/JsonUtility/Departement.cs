using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Departement
{
	public string _id;
	public string name;
	public string pin;

	public static Departement CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<Departement>(jsonString);
	}
}
