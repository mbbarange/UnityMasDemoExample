using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mascaret;

public class CheckMascaret : MonoBehaviour {

	// Use this for initialization
	void Start () {
		VRApplication mascaret = VRApplication.Instance;

		Dictionary<string, List<Class>> classesList = mascaret.Model.AllClasses;

		Debug.Log ("==== Printing Class List in Model ========");
		foreach (KeyValuePair<string, List<Class>> cl in classesList)
		{
			Debug.Log(" ============================================= ");
			Class c = cl.Value[0];
			Debug.Log (c.getFullName());
			Dictionary <string, Property> props = c.Attributes;
			foreach(KeyValuePair<string, Property> p in props)
			{
				Property property = p.Value;
				Debug.Log("    -> " + property.name + " : " + property.Type.name);
			}

			Dictionary<string,Behavior> behaviors = c.OwnedBehavior;
			Debug.Log("   ----- Behaviors : ");
			foreach(KeyValuePair<string,Behavior> bhs in behaviors)
			{
				Debug.Log(bhs.Value.getFullName());
				StateMachine stm = (StateMachine)bhs.Value;
				List<Region> regions = stm.Region;
				Region initialRegion = regions[0];
				List<Vertex> vertices = initialRegion.Vertices;
				foreach (Vertex vertex in vertices)
				{
					Debug.Log("    * "+vertex.name);
					List<Transition> outgoing = vertex.Outgoing;
					foreach(Transition t in outgoing)
					{
						Debug.Log("       --> " + t.Target.name);
					}
					List<Transition> incoming = vertex.Incoming;
					foreach(Transition t in incoming)
					{
						Debug.Log("       <-- " + t.Source.name);
					}
					if (vertex.GetType().ToString() == "Mascaret.State")
					{
						State state = (State)vertex;
						Operation doOperation = state.DoBehavior;
						if (doOperation != null) Debug.Log("        Do : " + doOperation.getFullName());
					}
				}
			}
/*
			Dictionary<string,InstanceSpecification> entities = c.Instances;
			Debug.Log("   ----- instances : " );
			foreach (KeyValuePair<string, InstanceSpecification> instanceKV in entities)
			{
				Debug.Log(instanceKV.Value.getFullName());
			}
*/
		}

		Dictionary<string, InstanceSpecification> instances = mascaret.getEnvironment().InstanceSpecifications;
		Debug.Log("Nb Instances : " + instances.Count);

		Debug.Log ("==== Printing Entity List in Model ========");
		foreach (KeyValuePair<string, InstanceSpecification> instanceKV in instances) 
		{
			Debug.Log(" ============================================= ");
			InstanceSpecification instance = instanceKV.Value;
			Debug.Log(instance.getFullName () + " : " + instance.Classifier.getFullName());
			Dictionary <string, Slot> slots = instance.Slots;
			foreach(KeyValuePair<string, Slot> propertyValues in slots)
			{
				Slot propertyValue = propertyValues.Value;
				string propertyName = propertyValue.DefiningProperty.name;
				ValueSpecification valueSpecif = propertyValue.getValue();
				if (valueSpecif != null)
				{
					string value = "";

					if(valueSpecif.GetType().ToString() == "Mascaret.LiteralInteger")
					{
						LiteralInteger integer = valueSpecif as LiteralInteger;
						int intValue = integer.IValue;
						value += intValue;
					}
					else if (valueSpecif.GetType().ToString() == "Mascaret.InstanceValue")
					{
						InstanceValue instanceValue = valueSpecif as InstanceValue;
						InstanceSpecification instanceSpecif = instanceValue.SpecValue;
						value = instanceSpecif.getFullName();
					}

					Debug.Log(" ----> " + propertyName + " = " + value);
				}
				else 
				{
					Debug.Log(" ----> " + propertyName + " not set");
				}
			}
			List<StateMachineBehaviorExecution> stmBEs = instance.SmBehaviorExecutions;
			foreach(StateMachineBehaviorExecution stmBE in stmBEs)
			{
				Debug.Log("    - Execute : " + stmBE.getStateMachine().getFullName());
				//Debug.Log("        * CurrentState : " + stmBE.CurrentState.name);
			}
			
		}

	}

}
