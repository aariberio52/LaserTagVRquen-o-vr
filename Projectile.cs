﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public LayerMask collisionMask;
    public float speed = 10;
    public float damage = 2;

    float lifetime = 3;

    void Start()
    {
        Destroy(gameObject, lifetime);

        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if (initialCollisions.Length > 0)
        {
            OnHitObjetc(initialCollisions[0]);
        }
    }
    

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
	void Update ()
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);

       
	}

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        } 
    }
    
    void OnHitObject(RaycastHit hit)
        {
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeHit(damage, hit);
        }
            GameObject.Destroy (gameObject);
        }

    void OnHitObjetc(Collider c)
    {
        IDamageable damageableObject = c.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(damage);
        }
        GameObject.Destroy(gameObject);
    }
}
