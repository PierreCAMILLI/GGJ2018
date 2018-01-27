using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private KeyCode[] reset; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (reset.Any(x => Input.GetKeyDown(x)))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}