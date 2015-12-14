using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mascaret;
using System.IO;


public class UnityMascaretInterface : MonoBehaviour {
	
	public VRApplication mascaret;
	public GameObject gui_interface;
//	private Dictionary<string, OSDWindow> windows = new Dictionary<string, OSDWindow> ();
	
	private string identifiant;
	private string etablissement;
	
	public void printEntity(string entityName)
	{
		//OSDWindow window = new OSDWindow (entityName);
		//	windows.Add (entityName, window);
	}
	
	public void hideEntity(string entityName)
	{
		//windows.Remove (entityName);
		//Debug.Log ("TOPRINT == FALSE");
	}
	
	void Start()
	{
		mascaret = VRApplication.Instance;
		gui_interface = GameObject.Find("GUI");
		
		//gui_interface.SetActive (false);
		
	}
	
	public void OnGUI()
	{
		//int indice = 0;
		/*foreach (KeyValuePair<string, OSDWindow> win in windows) 
		{
			OSDWindow w = win.Value;
			w.show(indice);
			indice ++;
		}*/
	}
	
	public string Identifiant {
		get {
			return this.identifiant;
		}
		set
		{
			this.identifiant = value;
		}
	}
	
	public string Etablissement {
		get {
			return this.etablissement;
		}
		set
		{
			this.etablissement = value;
		}
	}
	
}

