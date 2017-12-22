using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown_script : MonoBehaviour {
	public GameObject GameCont_obj;
	public float MAX_TIME = 5;
	float timeCount;
	bool countDown = false;
	
	// 参照用
	public bool end = false; 

	// Use this for initialization
	void Start () {
		timeCount = MAX_TIME;
		GetComponent<Text>().text = ((int)timeCount).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameCont_obj.GetComponent<GameCont>().now_Game_scene == "Game_start_Face_hide"){
			GetComponent<Text>().text = "記憶！";
		}
		else if(GameCont_obj.GetComponent<GameCont>().now_Game_scene == "GameStart_Round_01"){
			if(countDown == false){
				StartCoroutine("before_CountDown_01");
			}

			else{
				timeCount -= Time.deltaTime;
				GetComponent<Text>().text = ((int)timeCount).ToString();
				if(timeCount <= 1){
					end = true;
					GetComponent<Text>().text = "終！";
				}
			}
		}
		else if(GameCont_obj.GetComponent<GameCont>().now_Game_scene == "text_ok_Round02"){
			if(countDown == false){
				StartCoroutine("before_CountDown_02");
			}

			else{
				timeCount -= Time.deltaTime;
				GetComponent<Text>().text = ((int)timeCount).ToString();
				if(timeCount <= 1){
					end = true;
					GetComponent<Text>().text = "終！";
				}
			}
		}
		else{
			timeCount = MAX_TIME;
			end = false;
			countDown = false;
			GetComponent<Text>().text = " ";
		}
	}
	private IEnumerator before_CountDown_01(){
		GetComponent<Text>().text = "福笑　始！";
		yield return new WaitForSeconds(2.0f);
		countDown = true;		
	}

	private IEnumerator before_CountDown_02(){
		GetComponent<Text>().text = "福笑　始！";
		yield return new WaitForSeconds(2.0f);
		countDown = true;		
	}
}
