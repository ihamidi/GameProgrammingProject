using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : StateMachineBehaviour
{
    public float speed = 10f;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBetShots;
    public float startTimeBetShots;
    private Transform player;
    public GameObject projectile;
    public int health = 100;
    private GameObject boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = animator.gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, player.position) > stoppingDistance)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(animator.transform.position, player.position) < stoppingDistance && Vector2.Distance(animator.transform.position, player.position) > retreatDistance)
        {
            animator.SetBool("isIdle", true);
        }
        else if (Vector2.Distance(animator.transform.position, player.position) < retreatDistance)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBetShots <= 0)
        {
            Vector2 bulletrotate = animator.transform.position - player.position;
            //Bullet1.Rotate(bulletrotate,Space.World);
            //Instantiate(projectile, animator.transform.position, Quaternion.identity);
            Quaternion bulletangle = new Quaternion();
            bulletangle.Set(bulletrotate.x, bulletrotate.y, 0, 0);


            //bulletrotate.y=bulletrotate.y+ Mathf.Cos((45 * Mathf.PI) / 180) * 1;
            //bulletrotate.x=bulletrotate.x+ Mathf.Cos((45 * Mathf.PI) / 180) * 1;
            //Instantiate(projectile, animator.transform.position, bulletangle);
            FireAtPlayer();
            timeBetShots = startTimeBetShots;
        }
        else
        {
            timeBetShots -= Time.deltaTime;
        }
    }

    protected void FireAtPlayer()
    {
        /*Instantiate(projectile);
        projectile.transform.position = transform.position;
        Vector2 direction = player.position - projectile.transform.position;
        direction.Normalize();
       // direction
        //direction.Set(direction.x +  2, direction.y +  2));
        projectile.GetComponent<Rigidbody2D>().velocity =
                direction;*/

        float angleStep = 360f / 5;
        float angle = 0f;
        Vector2 startPoint = boss.transform.position;
        Quaternion bulletangle = new Quaternion();
        Vector2 bulletrotate = boss.transform.position - player.position;
        bulletangle.Set(bulletrotate.x, bulletrotate.y, 0, 0);
        for (int i = 0; i <= 5 - 1; i++)
        {

            float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * 1;
            float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * 1;

            Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized;

            var proj = Instantiate(projectile, startPoint, bulletangle);
            proj.GetComponent<Rigidbody2D>().velocity =
                new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }
    }
}
