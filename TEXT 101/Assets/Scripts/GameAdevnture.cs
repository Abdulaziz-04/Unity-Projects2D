using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameAdevnture : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text storytext;
    [SerializeField] State variable;   //Creating a variable with classname State which stores the IntroStory
    State initialState;  //This will then accept the value via assignment 
    void Start()
    {
        initialState = variable;


        storytext.text = initialState.getState(); //This will return string into the main intro screen
    }


    // Update is called once per frame
    void Update()
    {
        manageState();
    }
    private void manageState()
    {
        State[] next = initialState.getNextState();
        for (int index = 0; index < next.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1+index))
            {
                initialState = next[index];
            }

        }
        storytext.text = initialState.getState();
    }
}
