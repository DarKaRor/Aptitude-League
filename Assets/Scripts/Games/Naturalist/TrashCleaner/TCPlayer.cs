using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TCPlayer : MonoBehaviour
{
    [SerializeField] Collider2D collider2d;
    Range speedVal;
    LayerMask noCollide;
    LayerMask defMask;

    Coroutine speedCoroutine;
    Coroutine collisionCoroutine;
    Coroutine magnetCoroutine;

    TopDownMovement movement;
    bool isMagnet = false;
    float maxDistance = 2f;

    int magnetIndex = -1;
    int collisionIndex = -1;
    int speedIndex = -1;
   
    void Start()
    {
        movement = GetComponent<TopDownMovement>();
        speedVal = new Range(10f, movement.speed);
        noCollide = LayerMask.NameToLayer("NoCollide");
        defMask = LayerMask.NameToLayer("Default");
    }

    void Update()
    {
        if (isMagnet)
        {
            List<Collectable> closeCollectables = TrashCleaner.instance.collectables
                .Where(i => Vector2.Distance(i.transform.position, transform.position) <= maxDistance && i.type == Collectables.Trash).ToList();
            foreach (Collectable collectable in closeCollectables)
            {
                if(collectable != null) collectable.targetPlayer = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            Collectable collectable = collision.GetComponent<Collectable>();
            if (collectable.collected) return;
            collectable.collected = true;
            switch (collectable.type)
            {
                case Collectables.Trash:
                    TrashCleaner.instance.GetTrash();
                    break;
                case Collectables.Speed:
                    if (speedCoroutine != null) StopCoroutine(speedCoroutine);
                    speedCoroutine = StartCoroutine(Speed());
                    TrashCleaner.instance.GetPowerUp();
                    break;
                case Collectables.Collision:
                    if (collisionCoroutine != null) StopCoroutine(collisionCoroutine);
                    collisionCoroutine = StartCoroutine(Collision());
                    TrashCleaner.instance.GetPowerUp();
                    break;
                case Collectables.Magnet:
                    if (magnetCoroutine != null) StopCoroutine(magnetCoroutine);
                    magnetCoroutine = StartCoroutine(Magnet());
                    TrashCleaner.instance.GetPowerUp();
                    break;
            }
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Magnet()
    {
        isMagnet = true;
        float time = 13f;
        if (magnetIndex != -1) TrashCleaner.instance.timers[magnetIndex].ResetTimer();
        else magnetIndex = TrashCleaner.instance.ActivateTimer(TrashCleaner.instance.magnet, time);
        yield return new WaitForSeconds(time);
        isMagnet = false;
        magnetCoroutine = null;
        magnetIndex = -1;
    }

    IEnumerator Speed()
    {
        movement.speed = speedVal.max;
        float time = 16f;
        if (speedIndex != -1) TrashCleaner.instance.timers[speedIndex].ResetTimer();
        else speedIndex = TrashCleaner.instance.ActivateTimer(TrashCleaner.instance.speed, time);
        yield return new WaitForSeconds(time);
        movement.speed = speedVal.min;
        speedCoroutine = null;
        speedIndex = -1;
    }

    IEnumerator Collision()
    {
        collider2d.gameObject.layer = noCollide;
        float time = 10f;
        if (collisionIndex != -1) TrashCleaner.instance.timers[collisionIndex].ResetTimer();
        else collisionIndex = TrashCleaner.instance.ActivateTimer(TrashCleaner.instance.collision, time);
        yield return new WaitForSeconds(time);
        collider2d.gameObject.layer = defMask;
        collisionCoroutine = null;
        collisionIndex = -1;
    }
}
