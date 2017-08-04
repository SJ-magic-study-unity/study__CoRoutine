/************************************************************
output
	Cotourune1-1
	--------
	Nest-1
	Cotourune3-1
	Update.
	Update.
	Nest-2
	Cotourune3-2
	Update.
	Nest-3
	--------
	Cotourune1-2
	Cotourune3-3
	Update.
	Cotourune1-3
	Update.
	Update.
	Update.
	Update.
	Update.
	Update.
	Update.
	Update.
	Update.
	Update.
	Update.
	Update.
************************************************************/
using UnityEngine;
using System.Collections;
using System.IO;

/************************************************************
************************************************************/
public class Control : MonoBehaviour {
	private int counter = 0;
	private bool b_printout = true;
	
	bool Is_1st = true;
	private StreamWriter LogFile;

	void Start () {
		LogFile = new StreamWriter("LogData.txt", false); //true=追記 false=上書き
		
		StartCoroutine("Coroutine1");
		StartCoroutine("Coroutine3");
	}
	
	void Update () {
		if(b_printout) print_Log("Update.");
		
		counter++;
		if(15 < counter){
			if(Is_1st){
				Is_1st = false;
				b_printout = false;
				
				Debug.Log("Finished");
			}
		}
	}
	
	void OnApplicationQuit()
	{
		LogFile.Close();
		Debug.Log("Good-bye");
	}
	
	public IEnumerator Coroutine1()
	{
		print_Log("Cotourune1-1");
		print_Log("--------");
		yield return StartCoroutine("Coroutine2");
		
		print_Log("--------");
		print_Log("Cotourune1-2");
		yield return null;
		
		print_Log("Cotourune1-3");
	}
	
	private IEnumerator Coroutine2()
	{
		print_Log("Nest-1");
		yield return null;
	
		print_Log("Nest-2");
		yield return null;
	
		print_Log("Nest-3");
	}
	
	public IEnumerator Coroutine3()
	{
		print_Log("Cotourune3-1");
		yield return null;
		
		print_Log("Cotourune3-2");
		yield return null;
		
		print_Log("Cotourune3-3");
	}
	
	private void print_Log(string message)
	{
		/********************
		********************/
		// Debug.Log(message);
		
		/********************
		********************/
		LogFile.WriteLine(message);
		// LogFile.Flush();
	}
}
