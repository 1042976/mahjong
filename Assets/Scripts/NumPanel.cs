using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumPanel : MonoBehaviour
{
    public GameObject N;
    private int cur_count;
    private int next_count;
    public delegate void ShowVirtualPKeyBoard(NumPanel np);
    public static event ShowVirtualPKeyBoard OnShowVirtualPKeyBoard;
    private void Awake()
    {
        next_count = 4;
        cur_count = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        //SetVisible(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (next_count != cur_count) {

            if (next_count < 0)
            {
                next_count = 0;
            }
            else if (next_count > 4)
            {
                next_count = 4;
            }
            cur_count = next_count;
            CounterPanelUI counterPanel = GameObject.Find("CounterPanelUI").GetComponent<CounterPanelUI>();
            GetComponent<Image>().sprite = counterPanel.digits_color[next_count];
            N.GetComponent<Image>().sprite = counterPanel.digits[next_count];
        }
    }

    private void SetVisible(bool visible)
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Renderer>().enabled = visible;
        }
    }

    public void SetCount(int _count) {
        //if (_count < 0)
        //{
        //    _count = 0;
        //}
        //else if (_count > 4)
        //{
        //    _count = 4;
        //}
        //CounterPanelUI counterPanel = GameObject.Find("CounterPanelUI").GetComponent<CounterPanelUI>();
        //GetComponent<Image>().sprite = counterPanel.digits_color[_count];
        //N.GetComponent<Image>().sprite = counterPanel.digits[_count];
        //count = _count;
    }

    public void InputNum() {
        OnShowVirtualPKeyBoard(this);
    }
    //private void OnMouseOver()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Debug.Log("NumPanel");
    //        GameObject.Find("CounterPanel").GetComponent<CounterPanel>().CreateVirtualKeyBoard(this.gameObject.transform.position);
    //    }
    //}

    public int COUNT
    {
        get { return next_count; }
        set { next_count = value; }
    }
}
