using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace Mascaret
{
    public class UnityBehaviorExecution : BehaviorExecution
    {
        public bool m_IsFinished;

        private Component m_Component;
        private MethodInfo m_Method;

        public UnityBehaviorExecution(Component comp, MethodInfo method)
        {
            this.m_Component = comp;
            this.m_Method = method;
        }

        public override void init(Behavior behavior, InstanceSpecification host, Dictionary<string, ValueSpecification> p, bool sync)
        {
            base.init(behavior, host, p, sync);

            this.m_Method.Invoke(this.m_Component, this.GetParameters(p) );
        }

        public override double execute(double dt)
        {
            if (this.m_IsFinished)
                return 0f;

            return Time.deltaTime;
        }

        private object[] GetParameters(Dictionary<string, ValueSpecification> p)
        {
            List<object> objs = new List<object>();
            if (p.Count > 0)
            {
                foreach (KeyValuePair<string, ValueSpecification> pair in p)
                {
                    Type valueType = pair.Value.GetType();
                    if (valueType.Equals(typeof(LiteralBoolean)))
                        objs.Add(pair.Value.getBoolFromValue());
                    else if (valueType.Equals(typeof(LiteralInteger)))
                        objs.Add(pair.Value.getIntFromValue());
                    else if (valueType.Equals(typeof(LiteralReal)))
                        objs.Add(pair.Value.getDoubleFromValue());
                    else if (valueType.Equals(typeof(LiteralString)))
                        objs.Add(pair.Value.getStringFromValue());
                    else
                    {
                        // To do
                    }
                }
            }
            return objs.ToArray();
        }

    }
}
