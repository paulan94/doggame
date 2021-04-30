using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFlower : SpawnedFlower
{
    public GameObject explosionEffect;


    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 20;
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
                Rigidbody rb = flowerCollider.GetComponent<Rigidbody>();
                BoxCollider boxCollider = flowerCollider.GetComponent<BoxCollider>();
                boxCollider.isTrigger = true;
                if (rb != null) {
                    rb.isKinematic = false;
                    Vector3 pointOfExplosion = transform.position;
                    rb.AddExplosionForce(50, pointOfExplosion, .75f, 2);
                }
                SpawnedFlower flower = flowerCollider.gameObject.GetComponent<SpawnedFlower>();
                if (!flower.isDead) flower.TakeDamage(500);
            }
        }
    }

    public override void LifeSpanFlower(){

        lifeTime = Random.Range(4,5);
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

    //debug purposes
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere (transform.position, .75f);
    }
}