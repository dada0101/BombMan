using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//炸弹类
public class Bomb2 : MonoBehaviour
{
    public GameObject explosionPrefab;                          //炸弹预制体
    public LayerMask levelMask;                                 //射线检测层
    private bool exploded = false;                              //是否已经爆炸
    // Start is called before the first frame update
    void Start()
    {
        //延迟3s进行爆炸
        Invoke("Explode", 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //被其他炸弹引爆
        if(!exploded && other.CompareTag("Explosion"))
        {
            CancelInvoke("Explode");
            Explode();
        }
    }
    //炸弹爆炸
    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GetComponent<MeshRenderer>().enabled = false;
        exploded = true;
        transform.Find("Collider").gameObject.SetActive(false);
        Destroy(gameObject, 0.3f);

        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.left));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.right));
    }

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        for(int i = 1; i <= 2; ++i)
        {
            //发出一条射线 hit为返回的碰撞体的信息 levelMask为要碰撞的层
            RaycastHit hit;
            Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), direction, out hit, i, levelMask);
            if (!hit.collider)
                Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
            else
                break;
        }

        yield return new WaitForSeconds(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
