using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform arrowProjectilePrefab;
    [SerializeField] private Transform shootPoint;

    private void Awake()
    {
        if (TryGetComponent<MoveAction>(out MoveAction moveAction))
        {
            moveAction.OnStartMoving += MoveActionOnStartMoving;
            moveAction.OnStopMoving += MoveActionOnStopMoving;
        }

        if (TryGetComponent<ShootAction>(out ShootAction shootAction))
        {
            shootAction.OnShootAction += ShootAction_OnShoot;
            shootAction.OnDrawBow += ShootAction_OnDrawBow;
        }
        
        if (TryGetComponent<SwordAction>(out SwordAction swordAction))
        {
            swordAction.OnSwordActionStarted += SwordAction_OnSwordActionStarted;
        }
    }

    private void ShootAction_OnDrawBow(object sender, EventArgs e)
    {
        animator.SetTrigger("ArrowDraw");
    }

    private void Start()
    {
        
    }
    

    private void SwordAction_OnSwordActionStarted(object sender, EventArgs e)
    {
        animator.SetTrigger("SwordSlash");
    }


    private void MoveActionOnStartMoving(object sender, EventArgs e)
    {
        animator.SetBool("isWalking", true);
    }

    private void MoveActionOnStopMoving(object sender, EventArgs e)
    {
        animator.SetBool("isWalking", false);
    }

    private void ShootAction_OnShoot(object sender, ShootAction.OnShootEventArgs e)
    {
        animator.SetTrigger("Shoot");

        Transform bulletProjectileTransform = 
            Instantiate(arrowProjectilePrefab, shootPoint.position, Quaternion.identity);
        BulletProjectile bulletProjectile = bulletProjectileTransform.GetComponent<BulletProjectile>();

        Vector3 targetUnitShootAtPosition = e.targetUnit.GetWorldPosition();
        targetUnitShootAtPosition.y = shootPoint.position.y;
        bulletProjectile.Setup(targetUnitShootAtPosition);
    }
    
}
