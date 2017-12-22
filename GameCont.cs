using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameCont : MonoBehaviour {
	public GameObject OSC_obj;
	public string now_Game_scene; /// 現在のゲーム状態を示す。
	public string before_Game_scene; /// 一個前のゲームの状態を示す。

	//////........... GameStart_FaceHide .................
	public GameObject tako_prefab01_player01, tako_prefab01_player02;
	public GameObject tako_prefab02_player01, tako_prefab02_player02;
	public GameObject tako_Holder_player01, tako_Holder_player02;
	public GameObject tako_Holder_player01_02, tako_Holder_player02_02;

	public float fadeTime = 1.0f;
	private float currentRemainTime;
	private SpriteRenderer spRenderer_player01, spRenderer_player02;
	private SpriteRenderer spRenderer_player01_02, spRenderer_player02_02;

	//////............ Round01 to Round02 .......................
	public GameObject textCont_obj;

	/////............. Round01 to Round02 Face fade ......................
	public GameObject eye_prefab, mouth_prefab, nose_prefab;
	public GameObject partsHolder_player01, partsHolder_player02;
	/*	private SpriteRenderer spR_parts_eye_01_player01,spR_parts_eye_01_player02,
	 						spR_parts_nose_player01,spR_parts_nose_player02,
							spR_parts_mouth_player01, spR_parts_mouth_player02;
							*/

	GameObject parts_eye01, parts_eye02, parts_nose01, parts_nose02, parts_mouth01, parts_mouth02;
	GameObject parts_eye03, parts_eye04;

	// ................ to Round02 ................................
	public bool face_hide_last = false;
	

	// Use this for initialization
	void Start () {
		now_Game_scene = "start";

		currentRemainTime = 0;

		
	}
	
	// Update is called once per frame
	void Update () {
		if(now_Game_scene == "start"){
			Start_Scene();
		}
		else if(now_Game_scene == "Game_start_Face_hide"){
			GameStart_FaceHide();
		}
		else if(now_Game_scene == "GameStart_Round_01"){
			Round01();
		}
		else if(now_Game_scene == "Round01_to_Round02"){
			Round01_to_Round02();
		}
		else if(now_Game_scene == "Round01_to_Round02_Face"){
			Round01_to_Round02_faca_fade();
		}
		else if(now_Game_scene == "inter_result"){
			Inter_Result();
		}
		else if(now_Game_scene == "GameStart_Round02_setup"){
			Round02_setup();
		}
		else if(now_Game_scene == "GameStart_Round02"){
			Round02_fade();
		}
		else if(now_Game_scene == "text_ok_Round02"){
			Round02();
		}
		else if(now_Game_scene == "Round02_to_result"){
			Round02_to_result();
		}
		else if(now_Game_scene == "FinalResult"){
			Debug.Log("終わったよ");
			parts_eye01.SetActive(true);
			parts_eye02.SetActive(true);
			parts_nose01.SetActive(true);
			parts_nose02.SetActive(true);
			Application.LoadLevel("Final_Result");
		}



	}


////// 最初の扇子開く前
	void Start_Scene(){
		if(OSC_obj.GetComponent<OSC_player01>().sensu_open == true){
			now_Game_scene = "Game_start_Face_hide";

			//player01....................////////////////////////////////
			GameObject tako_player01_01 = (GameObject)Instantiate(
			tako_prefab01_player01,
			new Vector3(0,0,-20),
			Quaternion.identity
			);
			tako_player01_01.transform.parent = tako_Holder_player01.transform;
			spRenderer_player01 = tako_player01_01.GetComponent<SpriteRenderer>();
			var color_player01 = spRenderer_player01.color;
			color_player01.a = 0.0f;
			spRenderer_player01.color = color_player01;

			//player02....................////////////////////////////////
			GameObject tako_player02_01 = (GameObject)Instantiate(
			tako_prefab01_player02,
			new Vector3(0,0,20),
			Quaternion.identity
			);
			tako_player02_01.transform.parent = tako_Holder_player02.transform;
			spRenderer_player02 = tako_player02_01.GetComponent<SpriteRenderer>();
			var color_player02 = spRenderer_player02.color;
			color_player02.a = 0.0f;
			spRenderer_player02.color = color_player02;
		}
	}

////// 扇子開いた後、顔が消えたり凧が出たりする。
	void GameStart_FaceHide(){
		currentRemainTime += Time.deltaTime;
		// フェードアウトの実装
		float alpha = currentRemainTime / fadeTime;

		var color_player01 = spRenderer_player01.color; //player01 
		var color_player02 = spRenderer_player02.color; // player02
		color_player01.a = alpha; //01
		color_player02.a = alpha; //02
		spRenderer_player01.color = color_player01; //01
		spRenderer_player02.color = color_player02; //02

		if(alpha >= 1){
			alpha = 1;
			StartCoroutine("Wait_2Seconds");
		}
	}
	private IEnumerator Wait_2Seconds(){
		yield return new WaitForSeconds(2.0f);
		now_Game_scene = "GameStart_Round_01";
	}

// Round01............................
	void Round01(){
		if(textCont_obj.GetComponent<Countdown_script>().end == true){
			currentRemainTime = 1.0f;// 次でも使いたいから初期化
			now_Game_scene = "Round01_to_Round02";
		}
	}
	
	//...................................
	void Round01_to_Round02(){
		currentRemainTime -= Time.deltaTime/2;
		// フェードアウトの実装
		float alpha = currentRemainTime / fadeTime;

		var color_player01 = spRenderer_player01.color; //player01 
		var color_player02 = spRenderer_player02.color; // player02
		color_player01.a = alpha; //01
		color_player02.a = alpha; //02
		spRenderer_player01.color = color_player01; //01
		spRenderer_player02.color = color_player02; //02

		if(alpha <= 0){
			alpha = 0;
			now_Game_scene = "Round01_to_Round02_Face";
		}
	}

//......................................................
	void Round01_to_Round02_faca_fade(){
		Vector3 nowPosition_player01 = tako_Holder_player01.transform.position;
		Vector3 nowPosition_player02 = tako_Holder_player02.transform.position;
		// player01 -> player01 ........................
		parts_eye01 = (GameObject)Instantiate(
			eye_prefab,
			new Vector3(nowPosition_player01.x, nowPosition_player01.y + 5, -20),
			Quaternion.identity
			);
		parts_eye01.transform.parent = partsHolder_player01.transform;

		
		// player01 -> player02 .........................
		parts_eye02 = (GameObject)Instantiate(
			eye_prefab,
			new Vector3(-nowPosition_player01.x, nowPosition_player01.y + 5, 20),
			Quaternion.identity
			);
		parts_eye02.transform.parent = partsHolder_player02.transform;


		//........... player02 -> player01 ....................
		
		parts_nose01 = (GameObject)Instantiate(
			nose_prefab,
			new Vector3(-nowPosition_player02.x, nowPosition_player02.y + 5, -20),
			Quaternion.identity
			);
		parts_nose01.transform.parent = partsHolder_player01.transform;


		//............ player02 -> player02 ...................
		parts_nose02 = (GameObject)Instantiate(
			nose_prefab,
			new Vector3(nowPosition_player02.x, nowPosition_player02.y + 5, 20),
			Quaternion.identity
			);
		parts_nose02.transform.parent = partsHolder_player02.transform;
		now_Game_scene = "inter_result";
	}

//..............................................................
	void Inter_Result(){
		StartCoroutine("to_Round02");

	}
	private IEnumerator to_Round02(){
		yield return new WaitForSeconds(4.0f);
		face_hide_last = true;

		currentRemainTime = 0;
		now_Game_scene = "GameStart_Round02_setup";
	}

//..............................................................
	void Round02_setup(){
		//player01....................////////////////////////////////
		GameObject tako_player01_02 = (GameObject)Instantiate(
		tako_prefab02_player01,
		new Vector3(0,0,-20),
		Quaternion.identity
		);
		tako_player01_02.transform.parent = tako_Holder_player01_02.transform;
		spRenderer_player01_02 = tako_player01_02.GetComponent<SpriteRenderer>();
		var color_player01 = spRenderer_player01_02.color;
		color_player01.a = 0.0f;
		spRenderer_player01_02.color = color_player01;

		//player02....................////////////////////////////////
		GameObject tako_player02_02 = (GameObject)Instantiate(
		tako_prefab02_player02,
		new Vector3(0,0,20),
		Quaternion.identity
		);
		tako_player02_02.transform.parent = tako_Holder_player02_02.transform;
		spRenderer_player02_02 = tako_player02_02.GetComponent<SpriteRenderer>();
		var color_player02 = spRenderer_player02_02.color;
		color_player02.a = 0.0f;
		spRenderer_player02_02.color = color_player02;

		face_hide_last = false;
		parts_eye01.SetActive(false);
		parts_eye02.SetActive(false);
		parts_nose01.SetActive(false);
		parts_nose02.SetActive(false);

		now_Game_scene = "GameStart_Round02";
	}


	void Round02_fade(){
		currentRemainTime += Time.deltaTime;
		// フェードアウトの実装
		float alpha = currentRemainTime / fadeTime;

		var color_player01_02 = spRenderer_player01_02.color; //player01 
		var color_player02_02 = spRenderer_player02_02.color; // player02
		color_player01_02.a = alpha; //01
		color_player02_02.a = alpha; //02
		spRenderer_player01_02.color = color_player01_02; //01
		spRenderer_player02_02.color = color_player02_02; //02

		if(alpha >= 1){
			alpha = 1;
			now_Game_scene = "text_ok_Round02";
		}
		//Debug.Log("Round02");
	}
	void Round02(){
		//Debug.Log("test");
		if(textCont_obj.GetComponent<Countdown_script>().end == true){
			currentRemainTime = 1.0f;
			now_Game_scene = "Round02_to_result";
		}
	}

	void Round02_to_result(){
		currentRemainTime -= Time.deltaTime/2;
		// フェードアウトの実装
		float alpha = currentRemainTime / fadeTime;

		var color_player01_last = spRenderer_player01_02.color; //player01 
		var color_player02_last = spRenderer_player02_02.color; // player02
		color_player01_last.a = alpha; //01
		color_player02_last.a = alpha; //02
		spRenderer_player01_02.color = color_player01_last; //01
		spRenderer_player02_02.color = color_player02_last; //02

		/// object 生成
		
		Vector3 nowPosition_player01 = tako_Holder_player01_02.transform.position;
		Vector3 nowPosition_player02 = tako_Holder_player02_02.transform.position;
		// player01 -> player01 ........................
		parts_mouth01 = (GameObject)Instantiate(
			mouth_prefab,
			new Vector3(nowPosition_player01.x, nowPosition_player01.y + 5, -20),
			Quaternion.identity
			);
		parts_mouth01.transform.parent = partsHolder_player01.transform;

		
		// player01 -> player02 .........................
		parts_mouth02 = (GameObject)Instantiate(
			mouth_prefab,
			new Vector3(-nowPosition_player01.x, nowPosition_player01.y + 5, 20),
			Quaternion.identity
			);
		parts_mouth02.transform.parent = partsHolder_player02.transform;


		//........... player02 -> player01 ....................
		
		parts_eye03 = (GameObject)Instantiate(
			eye_prefab,
			new Vector3(-nowPosition_player02.x, nowPosition_player02.y + 5, -20),
			Quaternion.identity
			);
		parts_eye03.transform.parent = partsHolder_player01.transform;


		//............ player02 -> player02 ...................
		parts_eye04 = (GameObject)Instantiate(
			eye_prefab,
			new Vector3(-nowPosition_player02.x, nowPosition_player02.y + 5, 20),
			Quaternion.identity
			);
		parts_eye04.transform.parent = partsHolder_player02.transform;
		now_Game_scene = "FinalResult";

		if(alpha <= 0){
			alpha = 0;
			//Debug.Log("test");
			now_Game_scene = "FinalResult";
		}
	}

}
