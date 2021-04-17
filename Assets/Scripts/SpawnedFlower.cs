using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedFlower : MonoBehaviour
{

    public int hitPoints = 33;
    public bool isDead = false;
    public int lifeTime;

    public PeeTargetSpawner spawner;
    public PeeGameManager gameManager;
    public AudioClip deathSound;

    //lower flower over time and then kill at 5 seconds

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<PeeGameManager>();
        spawner = FindObjectOfType<PeeTargetSpawner>();
        LifeSpanFlower();
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
        if (!spawner.gameEnd) spawner.SpawnObjectsInPlane(Random.Range(2,5));
        Destroy(this.gameObject, 1f);
    }

    public virtual void LifeSpanFlower(){

        lifeTime = Random.Range(8,15);
        Debug.Log("timeTime: " + lifeTime);
        StartCoroutine("LowerFlower");
        Destroy(this.gameObject, lifeTime);
    }

    IEnumerator LowerFlower(){
        Vector3 flowerPosition = this.transform.position;
        while (true) {
            flowerPosition.y -= .03f;
            transform.position = flowerPosition;
            yield return new WaitForSeconds(.75f);
        }
    }
    
}
