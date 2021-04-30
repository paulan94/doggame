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

    public ParticleSystem part;

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
        part.gameObject.SetActive(true);
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        part.Emit(emitParams, 1);
        if (hitPoints <= 0 && !isDead){
            isDead = true;
            Die();
        }
    }
    
    public virtual void Die()
    {
        gameManager.score += 10;
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        if (!spawner.gameEnd) spawner.SpawnObjectsInPlane(Random.Range(2,3));
        Destroy(this.gameObject, .3f);
    }

    public virtual void LifeSpanFlower(){

        lifeTime = Random.Range(8,15);
        StartCoroutine("LowerFlower");
        Destroy(this.gameObject, lifeTime);
    }

    IEnumerator LowerFlower(){
        Vector3 flowerPosition = this.transform.position;
        while (true) {
            flowerPosition.y -= .03f;
            transform.position = flowerPosition;
            yield return new WaitForSeconds(.7f);
        }
    }
    
}
