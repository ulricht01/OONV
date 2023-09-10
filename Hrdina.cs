using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OONV_Seminarka
{
    public class Hrdina : Postava, IArenaObserver
{

    private int potrebne_zkusenosti;
    private int level = 1;
    public int zkusenosti;
    private int skill_pts;
    public int akt_pozice;
    private static Hrdina instance;
    public Hrdina()
    {
        this.maxHealth = 10;
        this.health = maxHealth;
        this.sila = 1;
        this.obrana = 0;
        this.zkusenosti = 0;
        this.skill_pts = 0;
        this.exp = 0;
        this.potrebne_zkusenosti = 2;
        this.akt_pozice = 0;
    }

    public static Hrdina getInstance()
    {
        if (instance == null)
        {
            instance = new Hrdina();
        }
        return instance;
    }

    private int dej_pozici(HraciPlocha hraciPlocha, Hrdina hrdina)
    {
        return hraciPlocha.herniPoles[akt_pozice].postavy.IndexOf(hrdina);
    }
    public void pohyb_dopredu(HraciPlocha hraciPlocha)
    {
        this.dej_pozici(hraciPlocha, this);
        hraciPlocha.herniPoles[akt_pozice].postavy.Remove(this);
        hraciPlocha.herniPoles[akt_pozice+1].postavy.Add(this);
        akt_pozice += 1;
    }

    private void check_level()
    {
        while (this.zkusenosti >= this.potrebne_zkusenosti)
        {
            this.level += 1;
            this.potrebne_zkusenosti = level * 2;
            this.skill_pts +=2;
            this.vylepsi_skills();
            this.health = maxHealth;
        }
    }

    public int vypis_zkusenosti()
    {
        return zkusenosti;
    }

    public int vypis_potrebne_zkusenosti()
    {
        return potrebne_zkusenosti;
    }


    public int vypis_level()
    {
        return level;
    }

    public void get_zkusenosti(Postava postava)
    {
        this.zkusenosti += postava.exp;
        this.check_level();
    }

    private void vylepsi_skills()
    {
        Random random = new Random();
        while (skill_pts > 0)
        {
            int nah_cislo = random.Next(1,4);
            if (nah_cislo == 1)
            {
                sila +=1;
            }
            else if (nah_cislo == 2)
            {
                maxHealth +=1;
            }
            else if (nah_cislo == 3)
            {
                obrana +=1;
            }
            skill_pts -= 1;
        }
    }

    public void update()
    {
        Console.WriteLine("");
        Console.WriteLine($"Hrdinův status | Zdraví: {this.health}/{this.maxHealth}, Sila: {this.sila}, Obrana: {this.obrana}, Zkušenosti: {this.vypis_zkusenosti()}/{this.vypis_potrebne_zkusenosti()}, Level: {this.vypis_level()}");
        Console.WriteLine("");
    } 
}
}