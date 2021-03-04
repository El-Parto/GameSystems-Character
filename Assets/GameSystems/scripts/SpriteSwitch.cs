using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitch : MonoBehaviour
{
    public List<Sprite> sprites;
    public SpriteRenderer Rend;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().wholeNumbers = true;
        GetComponent<Slider>().maxValue = sprites.Count - 1;
        //tell slider to only use whole numbers the max value is equal to our max value minus 1/ As arrays start from 0, you need the max number then subtract 1 from it.


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //if you input the key "R"
        {
            RandomSprite(); //call this variable This variable is then used to call the void function below.
        }
    }
    void RandomSprite()
    {
        int rand = Random.Range(0, sprites.Count); // a random interger from a variable called sprites, and counting from that
        Rend.sprite = sprites[rand]; //rendering sprite, which is a random sprite in the "sprites" variable
        GetComponent<Slider>().value = rand; // assigns the slider.value to be a random value. Essntially a random value is put into the slider
    }

    public void ChangeSprite(float value) //float value, float is whatever slider has reached.
    {
        int roundValue = Mathf.RoundToInt(value);
        Rend.sprite = sprites[roundValue];
    }


}


