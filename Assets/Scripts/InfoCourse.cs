using UnityEngine;
using System.Collections;

public abstract class InfoCourse : MonoBehaviour
{
    [SerializeField]
    private GameMgr gameMgr;

    private string turn_str = "Turns: ";
    public string Turn_str
    {
        get
        {
            return turn_str;
        }
        set
        {
            turn_str = value;
        }
    }
    private bool checkpoint = false;
    public bool Checkpoint
    {
        get
        {
            return checkpoint;
        }
        set
        {
            checkpoint = value;
        }
    }
    private int position = 1;
    public int Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }
    private int turn = 1;
    public int Turn
    {
        get
        {
            return turn;
        }
        set
        {
            turn = value;
        }
    }
    public GameMgr GameMgr
    {
        get
        {
            return gameMgr;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init()
    {
        gameMgr = GameMgr.Instance;
    }
}