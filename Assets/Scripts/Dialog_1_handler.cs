using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_1_handler : MonoBehaviour
{
    public GameObject enemyPrefab;
    public void EndDialog()
    {
        Quaternion rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        Instantiate(enemyPrefab, new Vector3(-4.62f, 7.7f, -3.80552f), rotation);
    }
}
