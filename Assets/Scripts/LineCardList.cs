using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCardList : CardList
{
    public Vector3 _center;
    public Vector3 _interval;

    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {
        Creator.OnFinishedCreation += CheckCreation;
    }

    // Update is called once per frame
    void Update()
    {
        CheckNum();
        //CheckIfAllStatic();
    }

    public override void refreshList()
    {
        supposedPositions = new List<Vector3>(_nextNumToShow);
        Vector3 startPosition = GetStartPostion(_nextNumToShow);
        Vector3 curPostion = startPosition;
        //if (gameObject.name == DataCenter.DC.offhand)
        //{
        //    Debug.Log("startPosition: " + startPosition);
        //}
        for (int i = 0; i < _nextNumToShow; i++)
        {
            supposedPositions.Add(curPostion);
            allCards[i].Index = i;
            //allCards[i].SetPositionAndMoveType(curPostion, 0);
            allCards[i].CardPos = curPostion;
            //if (gameObject.name == DataCenter.DC.offhand)
            //{
            //    Debug.Log("allCards[i].CardPos = curPostion " + allCards[i].CardPos);
            //}
            curPostion += _interval;
        }
        if (_nextNumToShow > _curNumToShow)
        {
            for (int i = _curNumToShow; i < _nextNumToShow; i++)
            {
                allCards[i].gameObject.GetComponent<Renderer>().enabled = true;
            }
        }
        else if (_curNumToShow <= allCards.Count)
        {
            for (int i = _nextNumToShow; i < _curNumToShow; i++)
            {
                allCards[i].gameObject.GetComponent<Renderer>().enabled = false;
            }
        }
        _curNumToShow = _nextNumToShow;
    }
    protected override void CheckNum()
    {
        if (_curNumToShow != _nextNumToShow)
        {
            refreshList();
        }
    }

    //mouse click is allowed if all static
    public override void CheckIfAllStatic() {
        foreach (Card c in allCards) {
            if (!c.IsStatic()) {
                _isAllStatic = false;
                return;
            }
        }
        _isAllStatic = true;
    }
    protected override Vector3 GetStartPostion(int numOfCardsToShow) {
        Vector3 startPostion = new Vector3();
        int left = numOfCardsToShow / 2;
        if (numOfCardsToShow % 2 == 1)
        {
            startPostion = _center - left * _interval;
        }
        else
        {
            startPostion = _center - left * _interval + _interval / 2.0f;
        }
        return startPostion;
    }


    public Vector3 Center
    {
        get { return _center; }
        set { _center = value; }
    }

    public Vector3 Interval
    {
        get { return _interval; }
        set { _interval = value; }
    }

    
}
