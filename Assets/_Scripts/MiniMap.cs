/*
 * Reference
 * [1] Brackeys, “How To Make a Minimap in Unity”, Youtube.com, (Sep. 24, 2017),
 * https://www.youtube.com/watch?v=28JTTXqMvOU (accessed Nov. 18, 2023).
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    public Transform player;

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
