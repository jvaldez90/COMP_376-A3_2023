/*
 * The following code referenced from the 
 * COMP 376 - Lab 02 Roomba Vacuum Example for car movement
 */

using UnityEngine;
using TMPro;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float mSpeed = 5f;
    [SerializeField] private float mAngularSpeed = 50f;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] AudioSource mItem;
    [SerializeField] AudioSource speedFX;

    [SerializeField] static int total_score = 0;
    // Missions
    [SerializeField] GameObject pickUps;
    [SerializeField] GameObject dropOffs;
    public static bool mPickups = true;
    public static bool mDropOffs = false;

    // Sticker Decals
    [SerializeField] GameObject stickerBurger;
    [SerializeField] GameObject stickerSpeedy;

    // Car Colors
    [SerializeField] GameObject yellow;
    [SerializeField] GameObject red;
    [SerializeField] GameObject purple;
    [SerializeField] GameObject blue;
    [SerializeField] GameObject gray;
    string color = "yellow";

    private void Awake()
    {
        scoreText.text = "$ " + total_score.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (!Mathf.Approximately (vertical, 0.0f) || !Mathf.Approximately(horizontal, 0.0f))
        {
            Vector3 direction = new Vector3(0.0f, 0.0f, vertical);
            direction = Vector3.ClampMagnitude(direction, 1.0f);
            transform.Translate(direction * mSpeed * Time.deltaTime);
            transform.RotateAround(transform.position, Vector3.up, horizontal * mAngularSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            speedFX.Play();
        }else if (Input.GetKeyUp(KeyCode.W))
        {
            speedFX.Stop();
        }
        if (total_score < 0)
        {
            ResetScore();
        }
    }
    // Player Collision Detection Methods
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.transform.SetParent(transform);
        }
        // Colliding with Obstacles
        if (collider.gameObject.tag == "Boundary" || collider.gameObject.tag == "CityProperty" || collider.gameObject.tag == "Pedestrian" || collider.gameObject.tag == "Vehicule")
        {
            //Car has collided with a barrier, a building, a pedestrian, a house or a vehicule
            total_score -= 100;
            scoreText.text = "$ " + total_score.ToString();
        }
        // Colliding with Power Ups Items
        if (collider.gameObject.tag == "Coin")
        {
            mItem.Play();
            Destroy(collider.gameObject);
            total_score += 10;
            scoreText.text = "$ " + total_score.ToString();
        }
        if(collider.gameObject.tag == "BlueBox")    // Adding 30 seconds to Timer
        {
            mItem.Play();
            Destroy(collider.gameObject);
            
            Timer.AddMoreTime();
        }
        if (collider.gameObject.tag == "GreenBox")  // Doubling current score
        {
            mItem.Play();
            Destroy(collider.gameObject);
            total_score *= 2;
            scoreText.text = "$ " + total_score.ToString();
        }
        // Yellow Icon Mission Food Pick Ups:
        if (collider.gameObject.tag == "PickUp")
        {
            mItem.Play();
            Missions();             // Activate DropOff/ Deactivate PickUp
            Destroy(collider.gameObject);
        }
        // Green Icon Mission Delivery Drop Offs:
        if (collider.gameObject.tag == "DropOff")
        {
            mItem.Play();
            Missions();             // Activate PickUp/ Deactivate DropOff
            Destroy(collider.gameObject);           

            total_score += 200;
            scoreText.text = "$ " + total_score.ToString();
        }
        // Unlocking Sticker
        if (collider.gameObject.tag == "StickerSpeedy" || collider.gameObject.tag == "StickerBurger")
        {
            mItem.Play();
            UnlockSticker(collider.gameObject.tag);
            Destroy(collider.gameObject);
        }
        // Changing Car Colors
        if (collider.gameObject.name == "SprayCan")
        {
            mItem.Play();
            ChangeColor();
            //Destroy(collider.gameObject);
        }

    }
    void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.transform.SetParent(null);
        }
    }

    // Methods for Keeping track of Player Score
    public static int finalScore()
    {
        return total_score;
    }
    public static int ResetScore()
    {
        total_score = 0;
        return total_score;
    }

    //Mission Activate / De-Activate Game Objects
    public void Missions()
    {
        if (mPickups)
        {
            pickUps.SetActive(false);
            mPickups = false;
            dropOffs.SetActive(true);
            mDropOffs = true;
        }
        else if (mDropOffs)
        {
            dropOffs.SetActive(false);
            mDropOffs = false;
            pickUps.SetActive(true);
            mPickups = true;
        }
    }
    // Upgrades: Stickers as UI Display
    public void UnlockSticker(string name)
    {
        if (name == "StickerBurger")
        {
            stickerBurger.SetActive(true);
        }
        if(name == "StickerSpeedy")
        {
            stickerSpeedy.SetActive(true);
        }
    }
    public void ChangeColor()
    {
        if (color == "yellow")
        {
            yellow.SetActive(false);
            red.SetActive(true);
            color = "red";
        }
        else if (color == "red")
        {
            red.SetActive(false);
            purple.SetActive(true);
            color = "purple";
        }
        else if (color == "purple")
        {
            purple.SetActive(false);
            blue.SetActive(true);
            color = "blue";
        }
        else if (color == "blue")
        {
            blue.SetActive(false);
            gray.SetActive(true);
            color = "gray";
        }
        else 
        {
            gray.SetActive(false);
            yellow.SetActive(true);
            color = "yellow";
        }
    }
}
