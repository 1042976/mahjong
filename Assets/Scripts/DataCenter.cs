using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCenter : MonoBehaviour
{
    public static DataCenter DC;
    public Sprite[] EWSNKFZ;

    public Sprite[] FromOneToNine_I;

    public Sprite[] FromOneToNine_II;

    public Sprite[] FromOneToNine_III;

    public GameObject emptyCard;
    public Vector3 originalPos;
    public int maximumNumOfCards;

    public Vector3[] thirteenCardsPos; // the positions for 13 cards;
    //[HideInInspector]
    //public Dictionary<V>
    private GameObject spawnedCard;

    [HideInInspector]
    public Dictionary<int, Sprite> SPRITE_MAP; //id->sprite

    [HideInInspector]
    public Dictionary<Sprite, int> ID_MAP; //sprite->available id

    [HideInInspector]
    public Dictionary<int, int> COUNT_MAP; //id->count, delete once zero

    [HideInInspector]
    public List<int> AVAILABLE; //available id
    [HideInInspector]
    public List<int> UNAVAILABLE; //unavailable id(used-up id)
    [HideInInspector]
    public int emptySpriteID = 4;
    //record 

    //moveSpeed
    public float speed = 2.0f;

    //cardList name
    public string onHand = "CardListOwned";
    public string offhand = "CardListAbandoned";

    [HideInInspector]
    public int numOfCards = 4;
    
    private void Awake()
    {
        DC = this;
        //Initailize the map for card so that we can order them
        SPRITE_MAP = new Dictionary<int, Sprite>();
        ID_MAP = new Dictionary<Sprite, int>();
        COUNT_MAP = new Dictionary<int, int>();
        AVAILABLE = new List<int>();
        UNAVAILABLE = new List<int>();
        for (int i = 0; i < EWSNKFZ.Length + FromOneToNine_I.Length + FromOneToNine_II.Length + FromOneToNine_III.Length; i++) {
            AVAILABLE.Add(i);
        }
        int counter = 0;
        for (int i = 0; i < EWSNKFZ.Length; i++)
        {
            SPRITE_MAP[counter] = EWSNKFZ[i];
            ID_MAP[EWSNKFZ[i]] = counter;
            COUNT_MAP[counter] = numOfCards;
            ++counter;
        }
        for (int i = 0; i < FromOneToNine_I.Length; i++)
        {
            SPRITE_MAP[counter] = FromOneToNine_I[i];
            ID_MAP[FromOneToNine_I[i]] = counter;
            COUNT_MAP[counter] = numOfCards;
            ++counter;
        }
        for (int i = 0; i < FromOneToNine_II.Length; i++)
        {
            SPRITE_MAP[counter] = FromOneToNine_II[i];
            ID_MAP[FromOneToNine_II[i]] = counter;
            COUNT_MAP[counter] = numOfCards;
            ++counter;
        }
        for (int i = 0; i < FromOneToNine_III.Length; i++)
        {
            SPRITE_MAP[counter] = FromOneToNine_III[i];
            ID_MAP[FromOneToNine_III[i]] = counter;
            COUNT_MAP[counter] = numOfCards;
            ++counter;
        }

    }

    public int getTotalAvailableNum() {
        int sum = 0;
        foreach (int id in COUNT_MAP.Keys) {
            sum += COUNT_MAP[id];
        }
        return sum;
    }

}
