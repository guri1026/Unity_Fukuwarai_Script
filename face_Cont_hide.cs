using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class face_Cont_hide : MonoBehaviour {
	/// fade
	public float fadeTime = 1.0f;
	private float currentRemainTime;
	private SpriteRenderer spRenderer;
	////

	public GameObject GameCont_obj;

	// Use this for initialization
	void Start () {
		currentRemainTime = fadeTime;
		spRenderer = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameCont_obj.GetComponent<GameCont>().now_Game_scene == "Game_start_Face_hide"){
			// 残り時間
		currentRemainTime -= Time.deltaTime/2;

		// フェードアウトの実装
		float alpha = currentRemainTime / fadeTime;
		var color = spRenderer.color;
		color.a = alpha;
		if(alpha <= 0){
			alpha = 0;
		}
		spRenderer.color = color;
		}

		else if(GameCont_obj.GetComponent<GameCont>().now_Game_scene == "inter_result"){
			currentRemainTime += Time.deltaTime/2;

			// フェードアウトの実装
			float alpha = currentRemainTime / fadeTime;
			var color = spRenderer.color;
			color.a = alpha;
			if(alpha >= 1){
				alpha = 1;
			}
			spRenderer.color = color;
		}

		else if(GameCont_obj.GetComponent<GameCont>().face_hide_last == true){
			currentRemainTime -= Time.deltaTime/2;

			// フェードアウトの実装
			float alpha = currentRemainTime / fadeTime;
			var color = spRenderer.color;
			color.a = alpha;
			if(alpha <= 0){
				alpha = 0;
			}
			spRenderer.color = color;
		}
		
	}
}
