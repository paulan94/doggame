using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupFlower : SpawnedFlower
{


    //lower flower over time and then kill at 5 seconds

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("spawniong flower");
        hitPoints = 800;

        gameManager = FindObjectOfType<PeeGameManager>();
        spawner = FindObjectOfType<PeeTargetSpawner>();
        LifeSpanFlower();
    }

    public override void TakeDamage(int dmg){
        hitPoints -= dmg;
        part.gameObject.SetActive(true);
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        part.Emit(emitParams, 1);
        if (hitPoints <= 0 && !isDead){
            isDead = true;
            Die();
        }
    }
    
    public override void Die()
    {
        gameManager.score += 2000;
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        if (!spawner.gameEnd) spawner.SpawnObjectsInPlane(Random.Range(2,5));
        Destroy(this.gameObject, .3f);
    }

    public override void LifeSpanFlower(){

        lifeTime = Random.Range(15,20);
        StartCoroutine("LowerFlower");
        Destroy(this.gameObject, lifeTime);
    }

    IEnumerator LowerFlower(){
        Vector3 flowerPosition = this.transform.position;
        while (true) {
            flowerPosition.y -= .01f;
            transform.position = flowerPosition;
            yield return new WaitForSeconds(.5f);
        }
    }
    
}
