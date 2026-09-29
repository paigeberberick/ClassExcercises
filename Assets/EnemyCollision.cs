using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hitEffect.transform.position = collision.contacts[0].point;
            hitEffect.Play();
            Debug.Log("Enemy hit by Player!");
        }
    }
}

