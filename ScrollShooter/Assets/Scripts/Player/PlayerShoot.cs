using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform rightGunPoint;
    [SerializeField] private Transform leftGunPoint;
    [SerializeField] private AudioClip cantShootSound;

    public bool canShoot;
    public bool attack;
    public bool PlayerLookRight;

    private AudioSource source;    
    private Vector2 gunPoint;
    private Animator anim;

    public UnityEvent PlayerShooting;
    public UnityEvent OnBulletEnd;
    public UnityEvent OnRechargeStart;
    public UnityEvent OnRechargeEnd;

    private void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("SoundValue");
    }

    private void Update()
    {
        if(Input.GetButtonDown(GlobalStringVars.FIRE)) Shooting();

    }

    /// <summary>
    /// Стрельба в направлении движения
    /// </summary>
    private void Shooting()
    {
        ShootDirection();
        if (canShoot) PlayerShooting?.Invoke();
        else
        {
            source.clip = cantShootSound;
            source.Play();
        }
        
    }

    /// <summary>
    /// Направление стрельбы
    /// </summary>
    private void ShootDirection()
    {
        PlayerLookRight = gameObject.GetComponent<SpriteRenderer>().flipX;
        if (!PlayerLookRight) gunPoint = rightGunPoint.position;
        if (PlayerLookRight) gunPoint = leftGunPoint.position;
    }

    /// <summary>
    /// Выстрел
    /// </summary>
    public void OneShot()
    {
        source.Stop();
        attack = true;
        anim.SetTrigger("attack");
        Bullet currentBullet = Instantiate(bullet, gunPoint, Quaternion.identity);
    }

    /// <summary>
    /// Началась перезарядка
    /// </summary>
    public void RechargeStart()
    {
        canShoot = false;
    }

    /// <summary>
    /// Перезарядка закончилась
    /// </summary>
    public void RechargeEnd()
    {
        canShoot = true;
    }

}
