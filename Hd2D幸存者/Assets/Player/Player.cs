using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : 角色基类
{
    public Material 普通材质;
    public Material 受击材质;
    public Transform 技能表;
    public float 拾取范围;

    public int 天赋点 = 100;
    public int 真实天赋点 = 100;
    public int 生命值加成 = 0;
    public int 攻击力加成 = 0;


    public bool 玩家死亡 = false;
    public Animator ani;//动画控制器
    private Vector2 movementInput;
    private Vector3 movementDirection;
    private Rigidbody rb;
    public battleUI battleUI;

    public 角色基类 初始属性;

    public AudioClip 被击音效;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


    public void 同步初始属性()
    {
        shengmaxh = 初始属性.shengmaxh;
        shengminh = shengmaxh;
        最大经验值 = 初始属性.最大经验值;
        经验值 = 0;
        attack = 初始属性.attack;
        fangyu = 初始属性.fangyu;
        baoji = 初始属性.baoji;
        shanbi = 初始属性.shanbi;
        yidong_speed =初始属性.yidong_speed;
    }

    public void 天赋加成()
    {
        shengmaxh += 生命值加成 * 20;
        shengminh = shengmaxh;
        attack += 攻击力加成 * 5;
    }

    public void 取消天赋()
    {
        shengmaxh -= 生命值加成 * 20;
        shengminh = shengmaxh;
        attack -= 攻击力加成 * 5;
    }

    public void 升级()
    {
        等级 += 1;
        shengmaxh += 20;
        shengminh = shengmaxh;
        经验值 = 0;
        最大经验值 += 20;
        battleUI.打开三选一UI();

    }
    // Update is called once per frame
    void Update()
    {
        if (玩家死亡== false)
        {
            // 获取玩家输入
            HandleInput();

            // 更新动画参数
            UpdateAnimation();
            float hmove = Input.GetAxis("Horizontal");
            float vmove = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(hmove, 0, vmove).normalized * yidong_speed;

            if (hmove != 0 || vmove != 0)
            {
                ani.SetBool("移动中", true);
            }

            if (hmove == 0 && vmove == 0)
            {
                ani.SetBool("移动中", false);
            }
            if (hmove > 0)
            {
                //设置朝向右边
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (hmove < 0)
            {
                //设置朝向左边
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (技能表.childCount > 0)
            {

                foreach (Transform skill in 技能表)
                {
                    Skillbase s = skill.GetComponent<Skillbase>();
                    s.player = gameObject;
                    if (s.CDkey >= s.CDtime)
                    {
                        StartCoroutine(s.UseSkill());
                    }
                }
            }
        }


    }
    void HandleInput()
    {
        // 获取标准WASD输入
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementInput = new Vector2(horizontal, vertical).normalized;
    }

    void UpdateAnimation()
    {
        if (ani != null)
        {
            // 将世界空间的移动方向转换为角色本地空间
            Vector3 localMovement = transform.InverseTransformDirection(movementDirection);

            // 设置动画参数
            ani.SetFloat("Horizontal", localMovement.x);
            ani.SetFloat("Vertical", localMovement.z);
            ani.SetFloat("Speed", movementInput.magnitude);
        }
    }

    public void 死亡事件()
    {
        玩家死亡 = true ;
        ani.SetTrigger("死亡");
        battleUI.开始显示死亡UI();

    }
    public void 开始受击反馈()
    {
        StartCoroutine(受击反馈());
        if (被击音效 != null)
        {

            GetComponent<AudioSource>().volume = GameObject.Find("声音管理").GetComponent<声音管理>().SE音量;
            GetComponent<AudioSource>().clip = 被击音效;
            GetComponent<AudioSource>().Play();
        }
    }
    public IEnumerator 受击反馈()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().material = 受击材质;
        yield return new WaitForSeconds(0.3f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().material = 普通材质;
    }
}
