using System.Collections.Generic;
using System;

[Serializable]
public class Question
{
	public List<Answer> answers;
	public string _id;
	public string question;
}
