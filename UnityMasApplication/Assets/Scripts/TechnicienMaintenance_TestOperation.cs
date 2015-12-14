using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mascaret;
public class TechnicienMaintenance_TestOperation : BehaviorExecution {
	private int hauteur = 0;
	private GameObject hostGO;
	private GameObject trappeExt;
	private int state = 0;
	UnityEngine.Vector3 endPoint;
	
	public TechnicienMaintenance_TestOperation()
	{
	}
	public TechnicienMaintenance_TestOperation(Behavior specif,InstanceSpecification host,Dictionary<string,ValueSpecification> p,bool sync) : base(specif, host, p,sync)
	{
	}
	public override void init(Behavior specif,InstanceSpecification host,Dictionary<string,ValueSpecification> p,bool sync)
	{
        hostGO = GameObject.Find("tech1");
        endPoint = GameObject.Find("toolbox").transform.position;
    }
	override public double execute (double dt)
	{

		Debug.LogWarning ("********************************************************** TestOperation in technincien ");

        if ((UnityEngine.Vector3.Distance(hostGO.transform.position, endPoint) > 1))
        {
            hostGO.transform.position = UnityEngine.Vector3.Lerp(hostGO.transform.position, endPoint, 1 / (20*Time.deltaTime * (UnityEngine.Vector3.Distance(hostGO.transform.position, endPoint))));
            return 1;
        }
      else
            return 0;
		
	}
}