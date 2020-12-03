using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExampleTemplate
{
    public class BombModel : MonoBehaviour
    {
        [SerializeField] private GameObject _explosion;
        [Range(0.0f, 5.0f), SerializeField] private float _explosionRadius;
        [SerializeField] private float _radius;
        [SerializeField] LayerMask _layerMask;

        private void OnCollisionEnter(Collision collision)
        {
            _explosion.transform.localScale = new Vector3(_explosionRadius, _explosionRadius, _explosionRadius);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Collider[] objects = Physics.OverlapSphere(gameObject.transform.position, _radius, _layerMask);

            Services.Instance.CameraServices.CreateShake(ShakeType.Standart);

            foreach (Collider collider in objects)
            {
                collider.GetComponent<BotModel>().DestroyBotEffects();
            }

            gameObject.SetActive(false);
        }
    }
}
