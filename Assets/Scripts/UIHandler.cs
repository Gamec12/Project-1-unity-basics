using UnityEngine;
using TMPro;
public class UIHandler : MonoBehaviour
{

    public TMP_InputField textField;
    
   public void OnButtonClick()
    {
        Debug.Log("AW AW AW STOP CLICKING ON ME DUDE!!");
    }

    public void print()
    {
        Debug.Log(textField.text);
    }
}
