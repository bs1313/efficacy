using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;


public class NewBehaviourScript : MonoBehaviour {

	public Flowchart flowchart;
	public Text text;
	public Text toGo;
	public Text prompt;
	float time = 5.0f;
	float timeLeft;
	int aPress;
	int aLeft = 20;

	//bool testing = flowchart.GetBooleanVariable ("testing");



	// Use this for initialization
	void Start () {

		//testing = flowchart.GetBooleanVariable ("testing"); 
		//text = GetComponent<Text> (); 

	}


	
	// Update is called once per frame
	void Update () {

		if (flowchart.GetBooleanVariable ("testing") == false) {
			Debug.Log ("hmmmm");

			time -= Time.deltaTime;
			text.text = "Time:" + time;

			toGo.text = "Things left to do" + aLeft; 
			prompt.text = "Tap A to Mold that Clay!!";



			//tapping stuff
			if (Input.GetKeyDown (KeyCode.A)) {
				aPress++;
				aLeft--; 
			}




			if (time <= 0f){

				text.text = "";
				prompt.text = "";
				toGo.text = "";

				if (aLeft <= 0) {
				
					flowchart.ExecuteBlock("Success");
					flowchart.SetBooleanVariable ("testing", true);
					//flowchart.GetBooleanVariable ("testing") = true;

				} else if (aLeft > 0){
					flowchart.ExecuteBlock("Fail");
					flowchart.SetBooleanVariable ("testing", true);

				}

			}
		



		}





	}









}
