using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CardList onHand, offHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbandonCards() {
        onHand.SetMoveType(Card.keepStatic);
        offHand.SetMoveType(Card.keepStatic);
        foreach (Card c in offHand.allCards) {
            Destroy(c.gameObject);
        }
        offHand.allCards.Clear();
        offHand.allCards.TrimExcess();
        string offHandGroupName = offHand.gameObject.name;
        CounterPanel counterPanel = GameObject.Find("CounterPanel").GetComponent<CounterPanel>();
        for (int i = 0; i < onHand.allCards.Count; i++) {
            if (onHand.allCards[i].CardPos != onHand.supposedPositions[i]) {
                //counter update
                Debug.Log("onHand.allCards[i].CardID: " + onHand.allCards[i].CardID);
                counterPanel.counterunits[onHand.allCards[i].CardID].AddCount(-1);
                //send card from onHand to offHand
                onHand.allCards[i].GroupName = offHandGroupName;
                offHand.allCards.Add(onHand.allCards[i]);
                onHand.RemoveAt(i);
                --i;
            }
        }
        onHand.SetMoveType(Card.smoothMove);
        offHand.SetMoveType(Card.flashedMove);
        onHand.NumToShow = onHand.allCards.Count;
        offHand.NumToShow = offHand.allCards.Count;
        offHand.refreshList();

    }

}
