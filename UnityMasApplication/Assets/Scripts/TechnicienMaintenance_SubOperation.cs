
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mascaret;
public class TechnicienMaintenance_SubOperation : BehaviorExecution {
	private int hauteur = 0;
	private GameObject hostGO;
	private GameObject trappeExt;
	private int state = 0;
	int x = 1;

    UnityEngine.Vector3 endPoint;
    public TechnicienMaintenance_SubOperation()
	{
	}
	public TechnicienMaintenance_SubOperation(Behavior specif,InstanceSpecification host,Dictionary<string,ValueSpecification> p,bool sync) : base(specif, host, p,sync)
	{
	}
	public override void init(Behavior specif,InstanceSpecification host,Dictionary<string,ValueSpecification> p,bool sync)
	{
        // initialisation of variables 

        hostGO = GameObject.Find("tech2");
        endPoint = GameObject.Find("toolbox").transform.position;
        string name = "mukesh";
       
    }
	override public double execute (double dt)
	{  
        int y = 2;
       
        x = x + y;
		int result = test (x);
		while(x<40){
            //do some calculations and repeat until condition is false     
            //each time mascaret behaviour will execute this operation i    
            x = x+ result;


			Debug.Log ("****" + x + "*********************************SUBOPERATION in technincien ");
			result = test(x);
			return 0.1f;
		}

        //
        if ((UnityEngine.Vector3.Distance(hostGO.transform.position, endPoint) > 1))
        {
            hostGO.transform.position = UnityEngine.Vector3.Lerp(hostGO.transform.position, endPoint, 1 / (30 * Time.deltaTime * (UnityEngine.Vector3.Distance(hostGO.transform.position, endPoint))));
            return 1;
        }

        //Mascaret Behaviour is successfully terminated when it returns 0;
        // otherwise behaviour schedular will continue to execute this operation [only execute() body  until it returns 0 ]
        return 0;
	}

	int  test(int x){
		int t = 2; 
		int result;
		result = t * 2 - t / 2 + 2;
		return result;
	}

}