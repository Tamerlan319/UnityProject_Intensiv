using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text OtvetText, InputText;
    [SerializeField] private InputField inputField;
    [SerializeField] private string MyText;
    public void SaveInputText()
    {
        MyText = InputText.text;
    }

    public void ShowOtvetText()
    {
        if (MyText == "���")
        {
            OtvetText.text = "����� " + MyText + " ������!" + "\n" + "��������� �����...";
        }
        else if (MyText == "���")
        {
            OtvetText.text = "����� " + MyText + " ������!" + "\n" + "��������� �����...";
        }
        else
        {
            OtvetText.text = "����� " + MyText + " ��������!" + "\n" + "���������� ��� ���!";
        }
    }
}
