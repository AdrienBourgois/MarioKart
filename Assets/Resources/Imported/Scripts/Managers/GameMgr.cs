using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {

    [SerializeField]
    public int max_turn = 3;

    private static GameMgr instance = null;
    public static GameMgr Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = GameObject.FindGameObjectWithTag("GameMgr").GetComponent<GameMgr>();
            return instance;
        }
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }
}