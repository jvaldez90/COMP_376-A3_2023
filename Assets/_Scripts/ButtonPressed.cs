/*
 * REFERENCE:
 * Unity Documentation,"Button.OnCLick", (2016), 
 * https://docs.unity3d.com/530/Documentation/ScriptReference/UI.Button-onClick.html
 * (accessed Oct. 31, 2023).
 * 
 * COMP 376 - Lab 05 - MegaMan Example
 */

using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour
{
    // When the player presses a button,
    // we want to have a sound effects playing for that button

    [SerializeField] Button mPressed;
    [SerializeField] AudioSource mClick;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = mPressed.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        mClick = gameObject.GetComponent<AudioSource>();

    }
    public void TaskOnClick()
    {
        mClick.Play();
    }
}
