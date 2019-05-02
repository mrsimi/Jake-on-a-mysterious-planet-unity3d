﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		LevelGenerator.instance.AddPiece();
		LevelGenerator.instance.RemoveOldestPiece();
	}


}
