using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour {
	
	public EventManager EventManager = new EventManager();

	void Start ()
	{
		EventManager.Register(1,Aaa);
		EventManager.Invoke(1,1,"abc");
		
		EventManager.Register(2,Bbb);
		EventManager.Invoke(2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Aaa(params object[] param)
	{
		for (int i = 0; i < param.Length; i++)
		{
			print(param[i]);
		}
	}
	
	public void Bbb( params object[] param)
	{
		print(222);
	}
}
