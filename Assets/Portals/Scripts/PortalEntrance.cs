using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEntrance : MonoBehaviour
{
    Vector2 speedBefore = new Vector2();
    float TeleportTime = 5.5f;

    [Header("Auto Find Necessary Objects")]
    public bool AutoLocate = false;


    [Header("Properties")]
    public AudioSource teleportSound;
    public ParticleSystem chargeParticleSystem;
    public ParticleSystem ExitParticleEffect;


    [Header("Name Of Objects Related")]
    public GameObject connectedTeleporter;

    [Header("Shake Settings")]
    public bool CameraShake = false; // If I want to shake the camera
    private Transform shakeObject; // Object I want to shake 
    private float shakeDuration = 0.0f; // Duration of shake
    public float shakeDurationInput;
    public float shakeMag; // Strength of shake
    private float shakeDamping = 1.0f; // How fast it fades out 
    Vector3 intPos; // initial pos of object


    public void Awake()
    {
        if(AutoLocate == true)
        {
            connectedTeleporter = null;
        }

        if (CameraShake)
        {
            if (shakeObject == null)
            {
                shakeObject = Camera.main.transform;
                intPos = shakeObject.transform.position;
            }
        }
        chargeParticleSystem.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            // Captures the speed before teleport happens
            speedBefore = other.GetComponent<Rigidbody2D>().velocity;

            // Turns off the object
            other.gameObject.SetActive(false);

            //Teleports the Object
            StartCoroutine(TeleportPlayer(other.gameObject));
    }

    public IEnumerator TeleportPlayer(GameObject other)
    {
        //Checks to see if the Camera shake is allowed
        if (CameraShake == true)
        {
            shakeCamera();
        }
        //Plays the Particle Effect
        chargeParticleSystem.Play();
        //Plays the Sound Effect
        teleportSound.Play();

        connectedTeleporter.GetComponent<Collider2D>().enabled = false;


        // Time teleport takes
        yield return new WaitForSeconds(TeleportTime);

        // Moves the object that is teleported to the other portal 
        other.transform.position = new Vector2(connectedTeleporter.transform.position.x, connectedTeleporter.transform.position.y);

        // Turns the other object back on
        other.SetActive(true);

        // Sets the velocity to what it was before the teleport happened
        other.GetComponent<Rigidbody2D>().velocity = speedBefore;

        // Play the exit particle effect
        ExitParticleEffect.Play();

        yield return new WaitForSeconds(TeleportTime);

        connectedTeleporter.GetComponent<Collider2D>().enabled = true;


    }

    public void Update()
    {
        //Locates the Exit in the Scene
        if (AutoLocate == true)
        {
            if(gameObject.tag == "PortalEntrance")
            {
                connectedTeleporter = GameObject.Find("PortalExit");
                ExitParticleEffect = GameObject.Find("ExitExplosiveParticles").GetComponent<ParticleSystem>();
            }
            else
            {
                connectedTeleporter = GameObject.Find("PortalEntrance");
                ExitParticleEffect = GameObject.Find("EntranceExplosiveParticles").GetComponent<ParticleSystem>();
            }

        }

        //Shake Camera
        if(CameraShake == true)
        {
            if (shakeDuration > 0)
            {
                shakeObject.localPosition = intPos + Random.insideUnitSphere * shakeMag;
                shakeDuration -= Time.deltaTime * shakeDamping;
            }
            else
            {
                shakeDuration = 0.0f;
                shakeObject.localPosition = intPos;
            }
        }
    }

    public void shakeCamera()
    {
        shakeDuration = shakeDurationInput;
    }
}
