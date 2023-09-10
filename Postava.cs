using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OONV_Seminarka
{
    public abstract class Postava
{
    public bool alive = true;
    public int maxHealth;
    public int health;
    public int sila;
    public int obrana;
    public int exp;

    public void utok(Postava cil)
    {
        int hodnota_utoku = this.sila - cil.obrana;
        if (cil.check_alive() == true & this.check_alive() == true)
        {
            if (hodnota_utoku > 0)
            {
                cil.health = cil.health - hodnota_utoku;
                System.Console.WriteLine($"--> {this.GetType().Name} útočí za {hodnota_utoku}");
            }
            else
            {
                Console.WriteLine($"--> {this.GetType().Name}, útočí za 0, {cil.GetType().Name} má příliš silné brnění!");
            }
        }
    }

    private bool check_alive()
    {
        if (this.health <= 0)
        {
            alive = false;
        }
    return alive;
    }

}
}