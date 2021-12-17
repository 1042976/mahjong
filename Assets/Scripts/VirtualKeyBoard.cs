using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VirtualKeyBoard : MonoBehaviour
{
    public GameObject inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField.GetComponent<InputField>().text = "hhhhh";
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Physics2D.Raycast(screenPos, Vector2.zero) && this.gameObject.Equals(hit.transform.gameObject))
            {
                Debug.Log("Hit");
            }
            else
            {
                gameObject.SetActive(false);
            }

        }
    }

    public void ToZero() {
        inputField.GetComponent<InputField>().text = "0";
    }
    public void ToOne()
    {
        inputField.GetComponent<InputField>().text = "1";
    }
    public void ToTwo()
    {
        inputField.GetComponent<InputField>().text = "2";
    }
    public void ToThree()
    {
        inputField.GetComponent<InputField>().text = "3";
    }
    public void ToFour()
    {
        inputField.GetComponent<InputField>().text = "4";
    }
    public void Cancel()
    {
        gameObject.SetActive(false);
    }

    public void IncreaseByOne() {
        string text = inputField.GetComponent<InputField>().text;
        switch (text) {
            case "0" :
                inputField.GetComponent<InputField>().text = "1";
                break;
            case "1":
                inputField.GetComponent<InputField>().text = "2";
                break;
            case "2":
                inputField.GetComponent<InputField>().text = "3";
                break;
            case "3":
                inputField.GetComponent<InputField>().text = "4";
                break;
            case "4":
                inputField.GetComponent<InputField>().text = "4";
                break;
            default:
                inputField.GetComponent<InputField>().text = "0";
                break;
        }
    }

    public void DecreaseByOne()
    {
        string text = inputField.GetComponent<InputField>().text;
        switch (text)
        {
            case "0":
                inputField.GetComponent<InputField>().text = "0";
                break;
            case "1":
                inputField.GetComponent<InputField>().text = "0";
                break;
            case "2":
                inputField.GetComponent<InputField>().text = "1";
                break;
            case "3":
                inputField.GetComponent<InputField>().text = "2";
                break;
            case "4":
                inputField.GetComponent<InputField>().text = "3";
                break;
            default:
                inputField.GetComponent<InputField>().text = "4";
                break;
        }
    }


}

