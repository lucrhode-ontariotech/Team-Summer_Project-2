using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUpdate : MonoBehaviour
{
    // Display current player lives on screen

    public int heartNumber = 0;

    public Sprite fullHeart;
    public Sprite brokenHeart;
    public Sprite lostHeart;
    public Sprite ironHeart;

    bool active = true;

    PlayerVariables player;
    SpriteRenderer sR;
    AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerVariables>();
        sR = GetComponent<SpriteRenderer>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprite currentSprite = sR.sprite;

        if ((player.playerCurrentHP >= heartNumber) && (player.immune) && (currentSprite != ironHeart))
        {
            sR.sprite = ironHeart;
        }
        else if ((player.playerCurrentHP >= heartNumber) && (currentSprite != fullHeart) && (!player.immune))
        {
            if (!(sR.enabled))
            {
                sR.enabled = true;
            }

            sR.sprite = fullHeart;
            active = true;
        }
        else if ((player.playerCurrentHP < heartNumber) && (active))
        {
            active = false;
            StartCoroutine(looseHeart());
        }
    }

    IEnumerator looseHeart()
    {
        audioS.Play();
        sR.sprite = brokenHeart;
        yield return new WaitForSecondsRealtime(0.3f);
        sR.sprite = lostHeart;
        yield return new WaitForSecondsRealtime(0.3f);
        sR.enabled = false;
    }
}
