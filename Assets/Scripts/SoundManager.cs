using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager instance;
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip step;
    [SerializeField]
    private AudioClip jump;
    [SerializeField]
    private AudioClip land;
    [SerializeField]
    private AudioClip punch;
    [SerializeField]
    private AudioClip heavyPunch;
    [SerializeField]
    private AudioClip ow;
    [SerializeField]
    private AudioClip ow2;
    [SerializeField]
    private AudioClip button;
    [SerializeField]
    private AudioClip pain;
    [SerializeField]
    private AudioClip audience;
    [SerializeField]
    private AudioClip heavenly;
    [SerializeField]
    private AudioClip disco;
    [SerializeField]
    private AudioClip computerHit;
    [SerializeField]
    private AudioClip dartHit;
    [SerializeField]
    private AudioClip error;
    [SerializeField]
    private AudioClip destruction;


    void Start()
    {
        //source = gameObject.GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }



    private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            Debug.Log("Temp");
            PlaySound("jump");
        }
    }


    public void PlaySound(string name)
    {
        if (name == "step")
        {
            source.clip = step;
        }

        if (name == "jump")
        {
            source.clip = jump;
        }

        if (name == "land")
        {
            source.clip = land;
        }

        if (name == "punch")
        {
            source.clip = punch;
        }

        if (name == "heavyPunch")
        {
            source.clip = heavyPunch;
        }

        if (name == "ow")
        {
            if (Random.Range(0, 10.0f) <= 7)
            {
                source.clip = ow;
            }
            else
            {
                source.clip = ow2;
            }
        }

        if (name == "button")
        {
            source.clip = button;
        }

        if (name == "computerHit")
        {
            source.clip = computerHit;
        }

        if (name == "dartHit")
        {
            source.clip = dartHit;
        }

        if (name == "pain")
        {
            source.clip = pain;
        }

        if (name == "computerHit")
        {
            source.clip = computerHit;

        }

        if (name == "error")
        {
            source.clip = error;
        }

        if (name == "destruction")
        {
            source.clip = destruction;
            source.volume = .25f;
        }

        if (name == "disco")
        {
            source.clip = disco;
            source.volume = .25f;
        }


        //source.Play();
        source.PlayOneShot(source.clip);
        //source.volume = 1;
    }
}