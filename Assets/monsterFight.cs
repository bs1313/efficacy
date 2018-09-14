using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Fungus;
using UnityEngine.EventSystems;

public class monsterFight : MonoBehaviour {

	public InputField intentionBox;
	public InputField compassionBox;
	public InputField hopeBox;
	public InputField perseverenceBox;
	//bool inputEnter = true;
	public Flowchart monsterFlow;
	public int inputLimit;

	public string intention; 
	public string compassionKey; 
	public string hopeKey; 

	public Text fightDirections;

	public char leftArrow;

	//find a way to add this to array, when the array is full the bit is done

	// Use this for initialization
	void Start () {




	}


	
	// Update is called once per frame
	void Update () {



		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.S) || 
			Input.GetKeyDown (KeyCode.D)
			|| Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow) || 
			Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) {

			inputLimit++;

		} 




		if (monsterFlow.GetBooleanVariable ("Open") == true) {
			Debug.Log ("here");
			intentionBox.gameObject.SetActive (true);
			if (Input.GetKeyDown(KeyCode.Return)){
				
				intention = intentionBox.text;
				Debug.Log (intention.ToString());

				intentionBox.gameObject.SetActive (false);

				monsterFlow.ExecuteBlock("Possible");
				monsterFlow.SetBooleanVariable ("Open", false);
			}
				
		}







		if (monsterFlow.GetBooleanVariable ("bCompassion") == true) {
			Debug.Log ("here");
			compassionBox.gameObject.SetActive (true);



			if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow) || 
				Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) {

				compassionBox.text = compassionBox.text + " " + EventType.KeyDown;
				compassionBox.caretPosition = compassionBox.text.Length;
				inputLimit++;

			} 


//			if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.S) || 
//				Input.GetKeyDown (KeyCode.D) ){
//
//				compassionBox.text = compassionBox.text + "\0" + EventType.KeyDown;
//				inputLimit++;
//
//			}






			if (Input.GetKeyDown (KeyCode.Return)) {


				if (inputLimit == 4) {

					compassionBox.characterLimit = compassionBox.text.Length;
				
					compassionKey = compassionBox.text;
					Debug.Log (compassionKey.ToString ());
					compassionBox.gameObject.SetActive (false);
					monsterFlow.SetBooleanVariable ("bCompassion", false);
					monsterFlow.ExecuteBlock ("rCompassion");
				}
			}
				

		}







		if (monsterFlow.GetBooleanVariable ("bHope") == true) {
			Debug.Log ("here");

			hopeBox.gameObject.SetActive (true);
			//fightDirections.text = compassionKey;

			if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow) || 
				Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) {

				hopeBox.text = hopeBox.text + " " + EventType.KeyDown;
				hopeBox.caretPosition = hopeBox.text.Length;
				inputLimit++;

			} 


			if (Input.GetKeyDown (KeyCode.Return)) {

				hopeBox.characterLimit = hopeBox.text.Length;

				hopeKey = hopeBox.text;
				Debug.Log (hopeKey.ToString ());
				hopeBox.gameObject.SetActive (false);
				monsterFlow.SetBooleanVariable ("bHope", false);
				monsterFlow.ExecuteBlock ("rHope");

			}
				

		}







		
	}







}
