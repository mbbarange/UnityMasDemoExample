using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mascaret;

public class Box_ChangeColor : BehaviorExecution
{

    public Box_ChangeColor()
    {
    }

    public override void init(Behavior specif, InstanceSpecification host, Dictionary<string, ValueSpecification> p, bool sync)
    {
        base.init(specif, host, p, sync);
      //  _vitesseRotation = (this.Host.getProperty("vitesseRotation"));
    }

    override public double execute(double dt)
    {
        Debug.LogError(".;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;launching changeColor for box");
        Entity entity = (Entity)(this.Host);
        UnityShapeSpecification shape = (UnityShapeSpecification)(entity.ActiveShape);
        GameObject go = shape.EntityGO;

        go.transform.Rotate((float)-20 * 0.2f, 0f, 0f);
        if (go.GetComponent<Renderer>().material.color == UnityEngine.Color.red)
        {
            go.GetComponent<Renderer>().material.color = UnityEngine.Color.green;
        }
        else go.GetComponent<Renderer>().material.color = UnityEngine.Color.red;

        
        return 0;
    }

    private Slot _vitesseRotation;
}

