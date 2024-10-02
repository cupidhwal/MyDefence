using UnityEngine;

namespace Sample
{
    public class MoveRb : MonoBehaviour
    {
        private Rigidbody rb;
        public float moveSpeed = 1.0f;
        public float moveForce = 10;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            rb.AddForce(this.transform.forward * moveForce, ForceMode.Force);
        }

        private void FixedUpdate()
        {
            //Kinematic �̵�
            //rb.MovePosition(this.transform.position + Vector3.forward * Time.fixedDeltaTime * moveSpeed);

            //Dynamic �̵�
            //rb.AddForce(this.transform.forward * moveForce, ForceMode.Impulse);
        }
    }
}

/*
3D �浹ü (�浹 ������Ʈ)
. ���� �浹ü : �������� �ʴ� �浹ü
- Static : ��, �ǹ�, ū ����, 

. ���� �浹ü : �����̴� �浹ü - Rigidbody (������Ʈ�� �������� ������ ����)
- Kinematic : �ܺο��� ���� �������� ����, ���, �̵��ϴ� ����, ��
- Dynamic : �׿� ���������� ���ܵǴ� ������Ʈ

�浹üũ
: �� ������Ʈ�� ��� �浹ü(Collider)�� ������ �־�� �Ѵ�.
: �ൿ�� ��ü�� Rigidbody�� ������ �־�� �Ѵ�. ��, �̵��ϴ� �༮�� Rigidbody�� ������ �־�� �浹 ������ �����ϴ�.
: �̵��ϴ� Kinematic�� Dynamic�� �浹üũ ����



2D �浹ü (�浹 ������Ʈ)
. ���� �浹ü : �������� �ʴ� �浹ü
- Static : ��, �ǹ�, ū ����, 

. ���� �浹ü : �����̴� �浹ü - Rigidbody (������Ʈ�� �������� ������ ����)
- Static : Bodytype���� static ����
- Kinematic : �ܺο��� ���� �������� ����, ���, �̵��ϴ� ����, ��
- Dynamic : �׿� ���������� ���ܵǴ� ������Ʈ

�浹üũ
: �� ������Ʈ�� ��� �浹ü(Collider)�� ������ �־�� �Ѵ�.
: �ൿ�� ��ü�� Rigidbody�� ������ �־�� �Ѵ�. ��, �̵��ϴ� �༮�� Rigidbody�� ������ �־�� �浹 ������ �����ϴ�.
: �̵��ϴ� Kinematic�� Dynamic�� �浹üũ ����



//
AddForce : ForceMode 4����

ForceMode.Force (����, ���� ���)
- �ٶ�, �ڱ��ó�� ���������� ���� �ִ� ��
- ª�� �ð��� �߻��ϴ� ��

ForceMode.Acceleration (����, ���� ����)
- ������ �߷�
- ������ ��� ���� ������ ������ ���Ѵ�

ForceMode.Impulse (����, ���� ���)
- ����, Ÿ��
- ���������� �ۿ��ϴ� ��

ForceMode.VelocityChange (����, ���� ����)
- ������ �����ϰ� ���������� �ӵ��� ��ȭ�� �ִ� ��
 */