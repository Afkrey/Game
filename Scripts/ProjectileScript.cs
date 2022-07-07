using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int art = 5;
    private EnemyScript enemyScript = null;

    private void Update()
    {
        if (this.enemyScript != null)
        ProjectileMovement();
    }

    public void Test(EnemyScript enemyScript)
    {
        this.enemyScript = enemyScript;
        Debug.Log("Target set");
    }

    void ProjectileMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, this.enemyScript.gameObject.transform.position, 0.02f);

        if (transform.position == this.enemyScript.gameObject.transform.position)
            Destroy(gameObject);
    }
}
