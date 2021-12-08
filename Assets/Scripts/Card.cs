using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public static int keepStatic = 0;
    public static int flashedMove = 1;
    public static int smoothMove = 2;
    private string _group_name; //name of card list
    private int _index; //index in card list
    private int _move_type; // 0 flash, 1 has speed
    private int _cur_id;
    private int _next_id;
    private Sprite _sp;
    private Vector3 _cur_pos;
    private Vector3 _next_pos;
    private float speed = 2.0f;

    private void Awake()
    {
        //_sp = GetComponent<Sprite>();
        CardList.OnMoveTypeControl += SetMoveType;
        _group_name = "";
        this.gameObject.GetComponent<Renderer>().enabled = false;
        _cur_pos = transform.position;
        _cur_id = 4;
        _move_type = flashedMove;
    }
    private void Start()
    {
    }
    private void Update()
    {
        //if id change, change sprite
        if (_cur_id != _next_id)
        {
            //Debug.Log("Card ID: " + _next_id);
            _cur_id = _next_id;
            _sp = DataCenter.DC.SPRITE_MAP[_next_id];
            gameObject.GetComponent<SpriteRenderer>().sprite = _sp;
        }

        //check if position change
        if (_next_pos != _cur_pos && _move_type != keepStatic) {
            if (_move_type == smoothMove)
            { 
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _next_pos, step);
            }
            else if(_move_type == flashedMove){
                transform.position = _next_pos;
            }
            _cur_pos = transform.position;
        }
    }

    public Sprite CardSprite
    {
        get { return _sp; }
        set { _sp = value; }
    }


    public Vector3 CardPos
    {
        get { return _next_pos; }
        set { _next_pos = value; }
    }

    public int CardID
    {
        get { return _next_id; }
        set { _next_id = value; }
    }
    public int MoveType
    {
        get { return _move_type; }
        set { _move_type = value; }
    }

    public string GroupName {
        get { return _group_name; }
        set { _group_name = value; }
    }

    public int Index {
        get { return _index; }
        set { _index = value; }
    }
    public void SetPositionAndMoveType(Vector3 newPos, int newMoveType) {
        _next_pos = newPos;
        _move_type = newMoveType;
    }

    private void OnMouseDown()
    {
        CardList cardList = GameObject.Find(_group_name).GetComponent<CardList>();
        if (cardList.gameObject.name == DataCenter.DC.onHand)
        {
            if (_cur_pos == cardList.supposedPositions[_index])
            {
                SetPositionAndMoveType(_cur_pos + new Vector3(0, 1, 0), smoothMove);
            }
            else {
                SetPositionAndMoveType(cardList.supposedPositions[_index], smoothMove);
            }
            
        }
    }

    //check if static
    public bool IsStatic() {
        return _next_pos == _cur_pos;
    }

    //set move type
    public void SetMoveType(string tarName, int type) {
        if (_group_name == tarName) {
            _move_type = type;
        }
    }
}
