using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static Rigidbody r;
    static Transform t;
    private PlayerHealth ph;
    public AudioClip audioWolf;
    public AudioClip audioLostLife;
    public AudioSource audioSource;

    public float speed = 15.0f;
    public float rotationSpeed = 90.0f;
    public float force = 360.0f;

    private bool attacked = false;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        ph = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // vertical + horizontal input keys
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        // spacebar key
        if (Input.GetButton("Jump") && t.position.y < 2)
        {
            r.AddForce(t.up * force);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!attacked && collision.collider.CompareTag("Predator"))
        {
            attacked = true;
            audioSource.Stop();
            audioSource.PlayOneShot(audioWolf, 2f);
            Invoke("AudioLostLife", 1f);
            Invoke("Die", 2.5f);
            Invoke("Reset", 5f);
        }

        /*if (collision.gameObject.CompareTag("Item"))
        {
            ph.Eat();
            Debug.Log("Colliding with Item");

            if (PlayerInventory.Instance == null)
                Debug.Log("PI.I is null");
            PlayerInventory.Instance.InsertItem(new ItemObject(item: GetComponent<BeaverItems>().scriptableObjectRepresentation,
                                                            quantity: 1
                                                            ));
        }*/

        if (collision.gameObject.CompareTag("Fire"))
        {
            ph.Fire();
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            Debug.Log("IN WATER");
        }
    }

    void Die()
    {
        ph.Die();
    }

    void AudioLostLife()
    {
        audioSource.PlayOneShot(audioLostLife, 1.0f);
    }

    private void Reset()
    {
        attacked = false;
    }
}