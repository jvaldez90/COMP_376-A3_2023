/*
 * REFERECE:
 * Single Sapling Games, “Countdown Timer In Unity - Easy Beginners Tutorial/ 
 * Guide”, Youtube.com, (Jul. 1, 2018), 
 * https://www.youtube.com/watch?v=o0j7PdU88a4 (accessed Oct. 28, 2023).
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    static float currentTime = 0f;
    float startingTime = 60f;

    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] static string levelSelected;

    private void Awake()
    {
        levelSelected = OptionSetting.optionSettings();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (levelSelected == "Easy")
        {
            startingTime = 60 * 5;
        }
        if (levelSelected == "Medium")
        {
            startingTime = 60 * 3;
        }
        // else startingTime = 60 for Hard level
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0.00");
        if (currentTime <= 10)
        {
            countdownText.color = Color.red;
        }
        if(currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene(2);
        }
    }
    public static float AddMoreTime()
    {
        currentTime += 30;
        return currentTime;
    }
}
