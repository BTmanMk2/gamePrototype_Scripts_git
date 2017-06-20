using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drops
{
    public GameObject item;
    public float droprate;
}

public class Enemy_DropItem : MonoBehaviour {

    private Enemy_Master enemyMaster;
    public Drops[] itemsToDrop;

    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyDie += DropItems;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DropItems;
    }

    void SetInitialReferences()
    {
        enemyMaster = GetComponent<Enemy_Master>();
    }

    void DropItems()
    {
        if (itemsToDrop.Length > 0) {
            foreach(Drops item in itemsToDrop) {
                float r = Random.Range(0.0f, 1.0f);
                if (r < item.droprate) {
                    StartCoroutine(PauseBeforeDrop(item.item));
                }
            }
        }
    }

    IEnumerator PauseBeforeDrop(GameObject itemToDrop)
    {
        yield return new WaitForSeconds(0.05f);


        if (itemToDrop.GetComponent<Item_Master>() != null) {
            
            Vector3 dropPosition = new Vector3(enemyMaster.transform.position.x,
                enemyMaster.transform.position.y + 1,
                enemyMaster.transform.position.z);
            Quaternion dropRotation = new Quaternion(0, 0, 0, 0);

            GameObject dropItem = Instantiate(itemToDrop, dropPosition, dropRotation, null);
            dropItem.GetComponent<Item_Master>().CallEventObjectThrow();
            
        }
    }
}
