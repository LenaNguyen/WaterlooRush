using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour {
    public Button m_YourFirstButton;
   
    // Use this for initialization
    void Start () {
        Button btn1 = m_YourFirstButton.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick);
        //Calls the TaskOnClick/TaskWithParameters method when you click the Button

    }
	
	// Update is called once per frame
	void Update () {
       
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.single);
    }
}


