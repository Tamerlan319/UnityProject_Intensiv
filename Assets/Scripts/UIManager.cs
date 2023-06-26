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
        if (MyText == "НОС")
        {
            OtvetText.text = "Ответ " + MyText + " верный!" + "\n" + "Открываем дверь...";
        }
        else if (MyText == "нос")
        {
            OtvetText.text = "Ответ " + MyText + " верный!" + "\n" + "Открываем дверь...";
        }
        else
        {
            OtvetText.text = "Ответ " + MyText + " неверный!" + "\n" + "Попробуйте ещё раз!";
        }
    }
}
