using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftItem : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("bullet")) {
            Destroy(gameObject);
        }
    }

}
