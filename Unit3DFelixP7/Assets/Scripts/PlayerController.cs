using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody prb;
    public float jf2 = 300f;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem boomParticle;
    public ParticleSystem Dirt;
    public AudioClip jumpSound;
    public AudioClip Crash;
    private AudioSource playerAudio;
    public bool Dj = false;
    // Start is called before the first frame update
    void Start()
    {
        prb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround  && !gameOver)
        {
            prb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            Dirt.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            Dj = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Dj && !gameOver)
        {
            prb.AddForce(Vector3.up * jf2, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            Dirt.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            Dj = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            boomParticle.Play();
            playerAudio.PlayOneShot(Crash, 1.8f);
            Dirt.Stop();
        }
    }
}
