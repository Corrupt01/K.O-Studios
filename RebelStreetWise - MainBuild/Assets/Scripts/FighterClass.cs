//Created By Ethan Quandt 8/29/18
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterClass : MonoBehaviour {
	
	//Class Variables
	//Health
	public int currentHealth;
	public int totalHealth;
	public float defValue;
	public bool canRecieveDamage;

	//Movement
	public float jumpHeight;
	public float jumpTime;
	public float moveSpeed;
	public bool canJump;

	//Parts
	public GameObject wholeBody;
	public GameObject upperBody;
	public GameObject lowerBody;
	public GameObject highHit;
	public GameObject midHit;
	public GameObject lowHit;

	//Attacks
	public bool canAttack;
	public float comboTimer;
	//Attack1(Light 1)
	public float attack1Delay;
	public int attack1Damage;

	//Attack2(Light 2)
	public float attack2Delay;
	public int attack2Damage;

	//Attack3(Light 3)
	public float attack3Delay;
	public int attack3Damage;

	//Attack4(Heavy 1)
	public float attack4Delay;
	public int attack4Damage;

	//Attack5(Heavy 2)
	public float attack5Delay;
	public int attack5Damage;

	//Attack6(Heavy 3)
	public float attack6Delay;
	public int attack6Damage;

	//Attack7(Overhead)
	public float attack7Delay;
	public int attack7Damage;

	//Grab

	//Controller


	//combo list / registering
	public List<string> ComboNames = new List<string>();
	public List<string> ComboInputs = new List<string>();

	private string InputQueue = "";
	private List<string> PossibleComboQueue = new List<string> ();

	private bool FacingRight = true;
	private bool checkForCombo = false;


	//Class Functions
	//Recieve Damage
	public virtual void TakeDamage(){
	
	}
	//Block Damage
	public virtual void Block(){
	
	}
	//Stop attacking Combo
	public virtual void ComboBreak(){
		
	}
	//Lower Stance
	public virtual void Crouch(){
	
	}
	//Move Character Left and Right
	public virtual void Move(){
	
	}
	//Jump....
	public virtual void Jump(){
	
	}
	//Dash
	public virtual void Dash(){
		
	}
	//Light Attack 1
	public virtual void Attack1(){
	
	}
	//Light Attack 2
	public virtual void Attack2(){
	
	}
	//Light Attack 3
	public virtual void Attack3(){
	
	}
	//Heavy Attack 1
	public virtual void Attack4(){
	
	}
	//Heavy Attack 2
	public virtual void Attack5(){
	
	}
	//Heavy Attack 3
	public virtual void Attack6(){
	
	}
	//Overhead Attack
	public virtual void Attack7(){
		
	}
	//Grab Opponent
	public virtual void Grab(){
	
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		QueueInput ();
		RegisterQueue ();


	}

	public void QueueInput(){
		//TODO change to be called on input press
		//forward Movement
		if (Input.GetKeyDown (KeyCode.RightArrow) && FacingRight) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				InputQueue += "Forward+Space";
			} else if (Input.GetKeyDown (KeyCode.B)) {
				InputQueue += "Forward+B";
			} else {
				InputQueue += "Forward,";
			}
			//Block
		} else if (Input.GetKeyDown (KeyCode.RightArrow) && !FacingRight) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				InputQueue += "Backward+Space";
			} else if (Input.GetKeyDown (KeyCode.B)) {
				InputQueue += "Backward+B";
			} else {
				InputQueue += "Backward,";
			}
		}

		Debug.Log (InputQueue);
	}


	public void RegisterQueue(){
		List<string> temp = PossibleComboQueue;
		foreach (string _Combo in PossibleComboQueue) {
			if (!_Combo.Contains (InputQueue)) {
				temp.Remove(_Combo);
			}
		}
		PossibleComboQueue = temp;
		temp = null;
		if (PossibleComboQueue.Count == 1 && PossibleComboQueue.Count != ComboInputs.Count) {
			//do combo
			Debug.Log("Combo Met = " + PossibleComboQueue[0]);
//			foreach(){
//				
//			}
		}
		if (PossibleComboQueue.Count == 0) {
			ResetQueue ();
		}

	}

	public void ResetQueue(){
		InputQueue = "";
		PossibleComboQueue = ComboInputs;
	}

}
