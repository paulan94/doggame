using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFlower : SpawnedFlower
{
    PeeTargetSpawner spawner;
    PeeGameManager gameManager;
    public GameObject explosionEffect;


    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<PeeTargetSpawner>();
        gameManager = FindObjectOfType<PeeGameManager>();
        hitPoints = 50;
        
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
            gameManager.score += 20;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            HandleExplosion();
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion, 2);
            Destroy(this.gameObject, 2.1f);

    }

    public void HandleExplosion(){
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, .75f);
        foreach (var flowerCollider in hitColliders)
        {
            if (flowerCollider.gameObject.tag == "Flower"){
                Debug.Log(flowerCollider.gameObject);
                SpawnedFlower flower = flowerCollider.gameObject.GetComponent<SpawnedFlower>();
                if (!flower.isDead) flower.TakeDamage(500);
            }
        }

    }

    //debug purposes
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere (transform.position, .75f);
    }
}