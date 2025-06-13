using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldDirtDelete : MonoBehaviour
{

    [SerializeField] public GameObject Dirt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDirt(Vector3 spawnPosition)
    {
        //同じ位置にある同じタグのオブジェクトを探す
        Collider[] colliders = Physics.OverlapSphere(spawnPosition, 0.01f);

        foreach (var col in colliders)
        {
            if (col.gameObject.CompareTag("dirt"))
            {
                //古いオブジェクトを消す
                Destroy(col.gameObject);
                Debug.Log("古いオブジェクトを消した");
            }

        }

        //新しいオブジェクトを生成
        GameObject newDirt = Instantiate(Dirt, spawnPosition, Quaternion.identity);
        newDirt.tag = "dirt";
        Debug.Log("新しいオブジェクトを生成した");
    }

}
