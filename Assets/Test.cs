using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour {
	
	public EventManager EventManager = new EventManager();

	private event EventMgr Test1;
	private event EventMgr Test2;
	

	void Start ()
	{
		EventManager.IsPause = true;
		Test1 += Aaa;
		EventManager.Register(1,Test1);
		EventManager.Invoke(1,1,"abc");
		
		Test2 += Bbb;
		EventManager.Register(2,Test2);
		
		EventManager.Invoke(2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Aaa(int key, params object[] param)
	{
		for (int i = 0; i < param.Length; i++)
		{
			print(param[i]);
		}
	}
	
	public void Bbb(int key, params object[] param)
	{
		print(222);
	}
}
