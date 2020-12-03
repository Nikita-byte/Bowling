using UnityEngine;

namespace ExampleTemplate
{
    public sealed class BotModel : MonoBehaviour, IDestroyableObject
    {
        [Range(0.0f, 5.0f), SerializeField] private float _destroyBotByTime = 0.0f;

        [SerializeField] private GameObject _destroyBotParticle = null;
        private BallModel _ball;

        public GameObjectType GameObjectType { get; set; }

        public void SetObjects()
        {
            //todo
        }

        public void DestroyObject()
        {
            DestroyBotEffects();

            ObjectPool.Instance.ReturnObjectInToThePool( gameObject, GameObjectType.Aim);
        }

        private void OnTriggerEnter(Collider other)
        {
            _ball = other.gameObject.GetComponent<BallModel>();

            if (_ball)
            {
                DestroyBotEffects();
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            DestroyBotEffects();
        }

        private void OnParticleTrigger()
        {
            print("adadad");
            DestroyBotEffects();
        }

        public void DestroyBotEffects()
        {
            Instantiate(_destroyBotParticle, gameObject.transform.position, Quaternion.identity);

            gameObject.SetActive(false);
            //Services.Instance.CameraServices.CreateShake(ShakeType.Standart);

            //Invoke(nameof(DestroyBot), _destroyBotByTime);
        }
    }
}