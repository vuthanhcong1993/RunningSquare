using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Miêu tả cho toàn bộ hệ thống của các đối tượng.
//– Có thể bỏ qua sự khác biệt giữa thành phần của các đối tượng và các đối tượng cá nhân.
//– Xử lý tất cả các đối tượng trong cơ cấu Composite chung.

//Ưu điểm
//– Làm cho việc thêm các thành phần trong một cấu trúc tương đồng trở nên dễ dàng.
//– Làm cho các client đơn giản hơn, vì không cần phải biết là đang làm việc trên một leaf hoặc một thành phần của Composite.
//Mẫu Composite này rất “lợi hại”, nó chuyên trị những bài có dạng đệ qui, nó làm việc trên các đối tượng abstract, không làm việc với đối tượng cụ thể nên khả năng mở rộng cũng rất cao.
//Nhược điểm
//– Khó khăn trong việc hạn chế các loại thành phần trong một Composite.
public class CompositeDesign : MonoBehaviour {

}

public abstract  class BaseAttribute : MonoBehaviour
{
    public float dame = 0;
    public float def = 0;
    public float crit = 0;
    public  virtual void AddComponents(BaseAttribute a) { }
    public virtual void RemoveComponents(BaseAttribute a) { }
    public virtual void Caculate() { }
}

public class BladeComposite:BaseAttribute
{

    public List<BaseAttribute> componentss = new List<BaseAttribute>();

    private void Start()
    {
        dame = 5;
        def = 2;
    }

  public override  void AddComponents(BaseAttribute a)
    {
        componentss.Add(a);
    }

    public override void RemoveComponents(BaseAttribute a)
    {
        componentss.Remove(a);
    }

    public BaseAttribute GetCompenent(int a)
    {
        return componentss[a];
    }

  public override void Caculate()
    {
        

        for (int i = 0; i < componentss.Count; i++)
        {
            
            dame += componentss[i].dame* componentss[i].crit;
        }
    }
}

public class GemCrit:BaseAttribute
{
    public GemCrit(float critGem)
    {      
        crit = critGem;
    }

    
}

public class GemDefense : BaseAttribute
{
    private void Start()
    {     
        def = 30;
    }
}
//vd ao',mu~,..
public class DependAttribute: BladeComposite
{
    protected List<BladeComposite> blades = new List<BladeComposite>();
    public void AddBlade(BladeComposite blade)
    {
        blades.Add(blade);
    }

    public void RemoveBlade(BladeComposite blade)
    {
        blades.Add(blade);
    }

    private void Start()
    {
         
    }

    public override void Caculate()
    {
        BaseAttribute baseAttribute = new GemCrit(10);
        BladeComposite bladeComposite = new BladeComposite();
        bladeComposite.AddComponents(baseAttribute);
        blades.Add(bladeComposite);
        for (int i = 0; i < blades.Count; i++)
        {
            blades[i].Caculate();
        }
       
              
    }
}
