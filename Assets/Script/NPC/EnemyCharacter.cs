using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class EnemyCharacter : BaseCharacter
{
    [Header("Parameter")]
    public GameObject player;
    public float minDistance;
    public float maxDistance;
    public float moveSpeed;

    public bool follow;
    public float seenPlayer;

    public Transform hitCheck;
    public float attackRadius;
    public int attackDamage;
    public PlayerCharacter playerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCharacter = player.GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (!isDead)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (player.GetComponent<PlayerCharacter>()._playerPower == PlayerCharacter.playerPower.NORMAL)
            {
                if (distance > minDistance && follow)
                {
                    Move();
                    animator.SetBool("isRunning", true);
                }
                else
                {
                    animator.SetTrigger("isAttack");
                    animator.SetBool("isRunning", false);
                }
            }
            else if (player.GetComponent<PlayerCharacter>()._playerPower == PlayerCharacter.playerPower.WIDE)
            {
                if (distance < maxDistance && follow)
                {
                    MoveAway();
                    animator.SetBool("isRunning", true);
                }
                else
                {
                    animator.SetTrigger("isAttack");
                    animator.SetBool("isRunning", false);
                }
            }
            FaceToPlayer();
        }
        base.Update();
    }

    public override void Move()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        charController.SimpleMove(direction * moveSpeed * Time.deltaTime);
    }

    public void FaceToPlayer()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void MoveAway()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        Vector3 directionAway = this.transform.position - player.transform.position;

        transform.rotation = Quaternion.LookRotation(-direction);
        charController.SimpleMove(-direction * moveSpeed);
    }

    public void Attack()
    {
        if (Physics.CheckSphere(hitCheck.position, attackRadius))
        {
            playerCharacter.TakeDamage(attackDamage);
        }
    }

    public override void OnDead()
    {
        isDead = true;
        animator.SetBool("isDead", isDead);
    }
    private void OnDrawGizmos()
    {
        if (hitCheck != null)
            Gizmos.DrawWireSphere(hitCheck.position, attackRadius);
    }

}
