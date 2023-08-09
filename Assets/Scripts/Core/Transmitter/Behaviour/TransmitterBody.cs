using UnityEngine;

namespace Core.Transmitter
{
    public class TransmitterBody : MonoBehaviour
    {
        private const int screenWidth = 640;
        private const int screenHeigth = 640;

        [SerializeField] private MeshRenderer _screen;
        [SerializeField] private JoystickBody _leftJoystick;
        [SerializeField] private JoystickBody _rightJoystick;

        public Transmitter Transmitter { get; private set; }

        public void Apply(Transmitter transmitter)
        {
            Transmitter = transmitter;
        }

        public void SetTranslation(Camera camera)
        {
            var image = new RenderTexture(screenHeigth, screenWidth, 0);

            camera.targetTexture = image;

            _screen.material.SetTexture("_MainTex", image);
        }

        private void Update()
        {
            
        }
    }
}