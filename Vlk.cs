using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OONV_Seminarka
{
    public class Vlk : Postava
{
    public Vlk()
    {
        this.maxHealth = 5;
        this.health = maxHealth;
        this.sila = 1;
        this.obrana = 0;
        this.exp = 1;
    }
}
}