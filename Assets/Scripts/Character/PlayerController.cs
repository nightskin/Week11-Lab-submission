using Character.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class PlayerController : MonoBehaviour , IPausable
    {
        public CrossHairScript CrossHair => CrossHairComponent;
        [SerializeField] private CrossHairScript CrossHairComponent;

        private GameUIController gameUIController;
        public HealthComponent Health => healthComponent;
        private HealthComponent healthComponent;

        public InventoryComponent Inventory => inventoryComponent;
        private InventoryComponent inventoryComponent;


        public WeaponHolder Weapon => weaponHolderComponent;
        private WeaponHolder weaponHolderComponent;

        private PlayerInput playerInput;

        [SerializeField]  private ConsumableItem Consume;

        public bool IsFiring;
        public bool IsReloading;
        public bool IsJumping;
        public bool IsRunning;

        private void Awake()
        {
            if(gameUIController == null) gameUIController = FindObjectOfType<GameUIController>();
            if (playerInput == null) playerInput = GetComponent<PlayerInput>();
            if (Weapon == null) weaponHolderComponent = FindObjectOfType<WeaponHolder>();
            if (Health == null) healthComponent = GetComponent<HealthComponent>();
            if (Inventory == null) inventoryComponent = GetComponent<InventoryComponent>();
        }

        private void Start()
        {
            Health.TakeDamage(50);
        }

        public void OnPauseGame()
        {
            MyPauseManager.instance.PauseGame();
        }

        public void OnUnPauseGame()
        {
            MyPauseManager.instance.UnPauseGame();
        }

        public void PauseGame()
        {
            gameUIController.EnablePauseMenu();
            if(playerInput)
            {
                playerInput.SwitchCurrentActionMap("PauseActionMap");
            }
        }

        public void UnPauseGame()
        {
            gameUIController.EnableGameMenu();
            if (playerInput)
            {
                playerInput.SwitchCurrentActionMap("PlayerActionMap");
            }
        }
    }
}
