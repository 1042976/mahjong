using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumPanel : MonoBehaviour
{
    public GameObject N;
    public delegate void ShowVirtualPKeyBoard(Vector3 tarPos);
    public static event ShowVirtualPKeyBoard OnShowVirtualPKeyBoard;
    // Start is called before the first frame update
    void Start()
    {
        //SetVisible(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetVisible(bool visible)
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Renderer>().enabled = visible;
        }
    }

    private void SetCount(int _count) {
        CounterPanelUI counterPanel = GameObject.Find("CounterPanelUI").GetComponent<CounterPanelUI>();
        GetComponent<Image>().sprite = counterPanel.digits_color[_count];
        N.GetComponent<Image>().sprite = counterPanel.digits[_count];
        
    }

    public void InputNum() {
        OnShowVirtualPKeyBoard(gameObject.transform.position);
    }
    //private void OnMouseOver()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Debug.Log("NumPanel");
    //        GameObject.Find("CounterPanel").GetComponent<CounterPanel>().CreateVirtualKeyBoard(this.gameObject.transform.position);
    //    }
    //}
}
