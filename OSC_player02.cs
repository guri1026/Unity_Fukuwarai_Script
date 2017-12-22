using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class OSC_player02 : MonoBehaviour {
	////OSC///////

		private Queue queue;
		//public GameObject[] reciverObjects;

		int shake_count = 0;
		/// ease count
		public bool shake = false;
		public bool move_right = false;
		public bool move_left = false;
		public bool sensu_stand = false;
	// Use this for initialization
	void Start () {

		queue = new Queue();
		queue = Queue.Synchronized(queue);

		OSCHandler1.Instance.Init();
		OSCHandler1.Instance.PacketReceivedEvent += OnPacketReceived;

	}

	void OnPacketReceived(OSCServer server, OSCPacket packet){
		queue.Enqueue(packet);
	}
	
	// Update is called once per frame
	void Update () {
		while(0 < queue.Count){
			OSCPacket packet = queue.Dequeue() as OSCPacket;
			if(packet.IsBundle()){
				OSCBundle bundle = packet as OSCBundle;
				foreach(OSCMessage msg in bundle.Data){
					if(msg.Address == "/player02/shake/yes"){
						//Debug.Log("yes");
						shake_count += 2;
						if(shake_count > 50){
							shake_count = 50;
						}
					}
					else if(msg.Address == "/player02/shake/no"){
						//Debug.Log("no");
						///　振ったかどうかの判定のための関数
						shake_count -= 3;
						if(shake_count < 0){
							shake_count = 0;
						}
					}
					else if(msg.Address == "/player02/move/right"){
						move_left = false;
						move_right = true;
					}
					else if(msg.Address == "/player02/move/left"){
						move_right = false;
						move_left = true;
					}
					else if(msg.Address == "/player02/move/straight"){
						move_left = false;
						move_right = false;
					}

					
					if(msg.Address == "/player02/sensu/stand"){
						sensu_stand = true;
					}
					else{
						sensu_stand = false;
					}


				}
			}
		}

		//Debug.Log(shake_count);

		if(shake_count > 30){
			shake = true;
		}

		else{
			shake = false;
			move_right = false;
			move_left = false;
		}


	}



}
