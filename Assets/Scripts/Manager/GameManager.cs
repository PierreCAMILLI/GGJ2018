using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> {

    private int _level = 1;
    public int Level
    {
        get { return _level; }
    }

    [System.Serializable]
    public class TransfertManager
    {
        private float _counter;
        public float Counter
        {
            get { return _counter; }
            set { _counter = value; }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}