using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardList : MonoBehaviour
{

    [HideInInspector]
    public List<Card> allCards;

    [HideInInspector]
    public List<Vector3> supposedPositions;

    protected bool _isAllStatic;
    protected bool _isAllCreated;
    public int _curNumToShow;
    public int _nextNumToShow;
    public abstract void refreshList();
    protected abstract void CheckNum();
    public abstract void CheckIfAllStatic();
    protected abstract Vector3 GetStartPostion(int numOfCardsToShow);

    public delegate void MoveTypeControl(string tarName, int type);
    public static event MoveTypeControl OnMoveTypeControl;

    private void Awake()
    {
        _isAllStatic = false;
        _isAllCreated = false;
        allCards = new List<Card>();
        _curNumToShow = 0;
    }

    public void RemoveAt(int i) {
        allCards.RemoveAt(i);
        supposedPositions.RemoveAt(i);
    }
    public void SetMoveType(int type) {
        //Debug.Log("OnMoveTypeControl(gameObject.name, type): " + gameObject.name + "  " + type);
        OnMoveTypeControl(gameObject.name, type);
    }
    //sorting algorithm. use insertion algorithm since it is efficient for list that almost sorted.
    public void insertionSort()
    {
        OnMoveTypeControl(gameObject.name, Card.smoothMove);
        bool hasSorted = true;
        for (int i = 1; i < allCards.Count; i++) {
            int j = i - 1;
            Card tempCard = allCards[i];
            int tempID = allCards[i].CardID;
            while (j >= 0 && allCards[j].CardID > tempID) {
                hasSorted = false;
                allCards[j + 1] = allCards[j];
                --j;
            }
            allCards[j + 1] = tempCard;
        }
        if (hasSorted == false)
        {
            for (int i = 0; i < supposedPositions.Count; i++)
            {
                //allCards[i].SetPositionAndMoveType(supposedPositions[i], 1);
                allCards[i].CardPos = supposedPositions[i];
                allCards[i].Index = i;
            }
        }
    }

    public void CheckCreation(string tarName)
    {
        if (tarName == gameObject.name)
        {
            _isAllCreated = true;
            insertionSort();
        }
    }

    public bool IsAllStatic
    {
        get { return _isAllStatic; }
        set { _isAllStatic = value; }
    }

    public bool IsAllCreated
    {
        get { return _isAllCreated; }
        set { _isAllCreated = value; }
    }

    public int NumToShow
    {
        get { return _nextNumToShow; }
        set { _nextNumToShow = value; }
    }

    public bool IsEmpty() {
        return allCards == null || allCards.Count == 0;
    }
}
