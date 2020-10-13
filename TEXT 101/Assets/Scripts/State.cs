using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "State")] //As an option to regenerate the same class via unity GUI
public class State : ScriptableObject  //object type is independent i.e. not needed to be added alongwith an empty object 
{

    // Start is called before the first frame update
    [TextArea(10, 14)] [SerializeField] string storytext;
    [SerializeField] State[] next;
    public string getState()   // Just a public method which can be accessed by other files
    {
        return storytext;
    }
    public State[] getNextState()
    {
        return next;
    }
}
