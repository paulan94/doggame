using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedFlower : MonoBehaviour
{

    public int hitPoints = 33;
    public bool isDead = false;

    PeeTargetSpawner spawner;
    PeeGameManager gameManager;

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
            Debug.Log("spawnedflowerdmg");
            spawner.SpawnObjectsInPlane(5);
            Destroy(this.gameObject);
    }
    
}
