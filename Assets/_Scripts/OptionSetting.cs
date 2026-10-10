/*
 * REFERENCE:
 * Unity Documentation,"Button.OnCLick", (2016), 
 * https://docs.unity3d.com/530/Documentation/ScriptReference/UI.Button-onClick.html
 * (accessed Oct. 31, 2023).
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionSetting : MonoBehaviour
{
    public Button levelOption;
    static string levelSettings = "--";
    [SerializeField] TextMeshProUGUI difficultyLevel;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = levelOption.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    public void TaskOnClick()
    {
        if (levelOption.name == "EasyButton")
        {
            // On Easy Mode: Player will get 5 mins of playing time.
            levelSettings = "Easy";
        }
        if(levelOption.name == "MediumButton")
        {
            // On Medium Mode: Player will get 3 mins of playing time.
            levelSettings = "Medium";
        }
        if (levelOption.name == "HardButton")
        {
            // On Hard Mode: Player will get 1 min of playing time.
            levelSettings = "Hard";
        }
        difficultyLevel.text = levelSettings;
    }
    public static string optionSettings()
    {
        if (levelSettings == "Easy")
        {
            return "Easy";
        }
        else if (levelSettings == "Medium")
        {
            return "Medium";
        } else
        {
            return "Hard";
        }
    }
}
