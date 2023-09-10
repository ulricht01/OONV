using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OONV_Seminarka
{
    public class Boss : Postava
{
    public Boss()
    {
        this.maxHealth = 50;
        this.health = maxHealth;
        this.sila = 20;
        this.obrana = 10;
        this.exp = 25;
    }
}
}