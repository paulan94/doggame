using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFlower : SpawnedFlower
{
    PeeTargetSpawner spawner;
    PeeGameManager gameManager;
    PeeStreamController peeStreamController;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<PeeTargetSpawner>();
        gameManager = FindObjectOfType<PeeGameManager>();
        peeStreamController = FindObjectOfType<PeeStreamController>();
        hitPoints = 100;
    }



    public override void TakeDamage(int dmg){
        hitPoints -= dmg;
        if (hitPoints <= 0 && !isDead){
            isDead = true;
            Die();
        }
    }

    public override void Die()
    {
            gameManager.score += 50;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            peeStreamController.YellowPeeBostTrigger();
            Destroy(this.gameObject);
    }
}
