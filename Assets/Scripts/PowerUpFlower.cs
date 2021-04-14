using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFlower : SpawnedFlower
{

    public PeeStreamController peeStreamController;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 50;
        
        gameManager = FindObjectOfType<PeeGameManager>();
        spawner = FindObjectOfType<PeeTargetSpawner>();
        peeStreamController = FindObjectOfType<PeeStreamController>();
        LifeSpanFlower();
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
            if (!spawner.gameEnd) spawner.SpawnObjectsInPlane(Random.Range(8,12));
            Destroy(this.gameObject);
    }

    public override void LifeSpanFlower(){

        lifeTime = Random.Range(5,6);
        Debug.Log("timeTime: " + lifeTime);
        StartCoroutine("LowerFlower");
        Destroy(this.gameObject, lifeTime);
    }

    IEnumerator LowerFlower(){ //if it drops .5 it will be gone~
    //right now it is called 10times  = .04 * 14 = .4

        Vector3 flowerPosition = this.transform.position;
        while (true) {
            flowerPosition.y -= .03f;
            transform.position = flowerPosition;
            yield return new WaitForSeconds(.75f);
        }
    }
}
