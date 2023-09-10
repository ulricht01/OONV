using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OONV_Seminarka
{
   public class Kostlivec : Postava
{
    public Kostlivec()
    {
        this.maxHealth = 15;
        this.health = maxHealth;
        this.sila = 3;
        this.obrana = 1;
        this.exp = 4;
    }
}
}