using UnityEngine;

public class Key : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.keyObtained = true;
            GameManager.instance.audioSource.Play();
            Destroy(gameObject);
        }
    }
}
