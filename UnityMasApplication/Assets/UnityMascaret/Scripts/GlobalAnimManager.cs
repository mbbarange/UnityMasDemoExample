using UnityEngine;
using System.Collections;

public class GlobalAnimManager : MonoBehaviour {
    public static GlobalAnimManager Instance;

    [System.Serializable]
    public class Action
    {
        public string Name;
        public bool DoIt;
        public AtomicAction[] Composition;
    }

    [System.Serializable]
    public class AtomicAction
    {
        public string animationTrigger;
        public GameObject target;
        public GameObject placementFrame;
        public float animationLength;
    }


    public Action[] actions;


	// Use this for initialization
	void Start ()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i<actions.Length; i++)
        {
            if(actions[i].DoIt)
            {
                actions[i].DoIt = false;
                for(int j = 0; j<actions[i].Composition.Length; j++)
                {
                    AtomicAction action = actions[i].Composition[j];
                    if (action.target != null)
                    {
                        if(action.placementFrame != null)
                        {
                            Transform trans = action.target.transform;
                            trans.parent = action.placementFrame.transform.GetChild(0);
                            trans.localPosition = Vector3.zero;
                            trans.localRotation = Quaternion.identity;
                        }
                        if (action.animationTrigger != "")
                            action.target.GetComponent<Animator>().SetTrigger(action.animationTrigger);
                    }
                }
            }
        }
	
	}

    public void TriggerAnimation(string anim)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            if (actions[i].Name == anim)
            {
                actions[i].DoIt = true;
                return;
            }
        }
    }
}
