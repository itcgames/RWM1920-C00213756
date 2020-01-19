using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEntrance : MonoBehaviour
{
    GameObject Player;
    GameObject PortalExit;
    Vector2 speedBefore = new Vector2();
    float TeleportTime = 5.5f;




    [Header("Properties")]
    public AudioSource teleporting;
    public ParticleSystem particleSystem;
    public ParticleSystem ExitParticleEffect;

    [Header("Name Of Objects Related")]
    public string EntityToTeleport;
    public GameObject connectedTeleporter;

    [Header("Shake Settings")]
    //Camera Shake
    public bool CameraShake;
    private Transform t; // Object I want to shake 
    private float shakeDuration = 0.0f; // Duration of shake
    public float shakeDurationInput;
    public float shakeMag; // Strength of shake
    private float shakeDamping = 1.0f; // How fast it fades out 
    Vector3 intPos; // initial pos of object

    private void Awake()
    {
        if(t == null)
        {
            t = Camera.main.transform;
            intPos = t.transform.position;
        }
        particleSystem.Stop();
        Player = GameObject.Find(EntityToTeleport);
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == Player.name)
        {
            speedBefore = Player.GetComponent<Rigidbody2D>().velocity;
            Player.SetActive(false);
            StartCoroutine(TeleportPlayer());

        }
    }
    IEnumerator TeleportPlayer()
    {
        if (CameraShake == true)
        {
            shakeCamera();
        }
        particleSystem.Play();
        teleporting.Play();

        yield return new WaitForSeconds(TeleportTime);
        Player.transform.position = new Vector2(connectedTeleporter.transform.position.x, connectedTeleporter.transform.position.y);
        Player.SetActive(true);
        Player.GetComponent<Rigidbody2D>().velocity = speedBefore;
        ExitParticleEffect.Play();


    }

    private void Update()
    {
        if(shakeDuration > 0)
        {
            t.localPosition = intPos + Random.insideUnitSphere * shakeMag;
            shakeDuration -= Time.deltaTime * shakeDamping;
        }
        else
        {
            shakeDuration = 0.0f;
            t.localPosition = intPos;
        }
    }

    public void shakeCamera()
    {
        shakeDuration = shakeDurationInput;
    }
}
