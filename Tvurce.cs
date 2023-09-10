using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OONV_Seminarka
{
    public abstract class Tvurce
{
    public abstract Postava FactoryMethod();
}

public class VlkFactory : Tvurce
{
    public override Postava FactoryMethod()
    {
        return new Vlk();
    }
}

public class KostlivecFactory : Tvurce
{
    public override Postava FactoryMethod()
    {
        return new Kostlivec();
    }
}

public class BossFactory : Tvurce
{
    public override Postava FactoryMethod()
    {
        return new Boss();
    }
}
}