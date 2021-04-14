using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedFlower : MonoBehaviour
{

    public int hitPoints = 33;
    public bool isDead = false;

    PeeTargetSpawner spawner;
    PeeGameManager gameManager;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<PeeTargetSpawner>();
        gameManager = FindObjectOfType<PeeGameManager>();
    }

    public virtual void TakeDamage(int dmg){
        hitPoints -= dmg;
        if (hitPoints <= 0 && !isDead){
            isDead = true;
            Die();
        }
    }

    
    public virtual void Die()
    {
            gameManager.score += 10;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            spawner.SpawnObjectsInPlane(5);
            Destroy(this.gameObject);
    }
    
}
