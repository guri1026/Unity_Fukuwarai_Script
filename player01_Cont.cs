using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player01_Cont : MonoBehaviour {
	public GameObject OSC_player01_obj;
	public GameObject GameCont_obj;
	Rigidbody player01_rb;
	Vector3 nowPositoin;
	public float limitPosition_x, limitPosition_y_top;
	public float limitPosition_y_under;
	bool before_shake;

	void Start(){
		player01_rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
		nowPositoin = gameObject.transform.position;

		before_shake = OSC_player01_obj.GetComponent<OSC_player01>().shake;
		
		if(gameObject.transform.position.y >= limitPosition_y_top){
			gameObject.transform.position = new Vector3(nowPositoin.x,limitPosition_y_top,0);
			player01_rb.velocity = new Vector3(player01_rb.velocity.x, 0, 0);
		}
		else if(gameObject.transform.position.y <= limitPosition_y_under){
			gameObject.transform.position = new Vector3(nowPositoin.x,limitPosition_y_under,0);
			player01_rb.velocity = new Vector3(player01_rb.velocity.x, 0, 0);
		}

		if(gameObject.transform.position.x >= limitPosition_x){
			gameObject.transform.position = new Vector3(limitPosition_x,nowPositoin.y,0);
			player01_rb.velocity = new Vector3(0, player01_rb.velocity.y, 0);
		}
		else if(gameObject.transform.position.x <= -limitPosition_x){
			gameObject.transform.position = new Vector3(-limitPosition_x,nowPositoin.y,0);
			player01_rb.velocity = new Vector3(0, player01_rb.velocity.y, 0);
		}
		

				
	}

	void FixedUpdate(){
		if(GameCont_obj.GetComponent<GameCont>().now_Game_scene == "GameStart_Round_01"){
			if(OSC_player01_obj.GetComponent<OSC_player01>().shake == true){
				player01_rb.AddForce(0,1.0f,0);
			}
		
			else if(OSC_player01_obj.GetComponent<OSC_player01>().shake == false){
				player01_rb.AddForce(0,-1.0f,0);
			}

			if(OSC_player01_obj.GetComponent<OSC_player01>().move_right == true){
				/* 
				nowPositoin.x += position_x_increace;
				gameObject.transform.position = new Vector3(nowPositoin.x, nowPositoin.y, -10);
				*/
				player01_rb.AddForce(1.4f,0.0f,0);

			}
			else if(OSC_player01_obj.GetComponent<OSC_player01>().move_left == true){
				/* 
				nowPositoin.x -= position_x_increace;
				gameObject.transform.position = new Vector3(nowPositoin.x, nowPositoin.y, -10);
				*/
				player01_rb.AddForce(-1.4f,-0.0f,0);
			}

			if(before_shake == false && before_shake != OSC_player01_obj.GetComponent<OSC_player01>().shake){
				player01_rb.AddForce(0,50.0f,0);
				//Debug.Log("change");
			}

			if(OSC_player01_obj.GetComponent<OSC_player01>().sensu_stand == true){
				player01_rb.AddForce(0,-3.0f,0);
			}
		}
		else{
			player01_rb.velocity = new Vector3(0,0,0);
		}
	}
}
