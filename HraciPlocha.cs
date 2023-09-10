using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OONV_Seminarka
{
    public class HraciPlocha
{
    private static HraciPlocha instance;
    public List<HerniPole> herniPoles;

    public HraciPlocha()
    {
        herniPoles = new List<HerniPole>();
    }

    public static HraciPlocha get_instance()
    {
        if (instance == null)
        {
            instance = new HraciPlocha();
        }
        return instance;
    }

    public void vykresli_desku()
    {
        Console.WriteLine("======== DESKA ========");
        for (int i = 0; i < herniPoles.Count; i++)
        {
            Console.Write("Pole " + herniPoles[i].cislo_pole + ": ");
            List<Postava> postavyNaPoli = herniPoles[i].postavy;
            postavyNaPoli.RemoveAll(postava => !postava.alive);
            foreach (Postava postava in postavyNaPoli)
            {
                if (postavyNaPoli.Count > 0)
                {
                    Console.Write(postava.GetType().Name + " ");
                }
            }
            if (postavyNaPoli.Count == 0)
            {
                Console.Write("Vyčištěno!");
            }
            Console.WriteLine();
        }

    }

    private void pridej_pole(HerniPole herniPole)
    {
        herniPoles.Add(herniPole);
    }

    private void vytvor_herni_pole()
    {
        for (int i = 1; i <= 10; i++)
        {
            HerniPole herniPole = new HerniPole(i);
            this.pridej_pole(herniPole);
        }
    }

    public void priprav_hru(Postava hero)
    {
        this.vytvor_herni_pole();

        Tvurce tvurceVlk= new VlkFactory();
        Tvurce tvurceKostlivec = new KostlivecFactory();
        Tvurce tvurceBoss = new BossFactory();

        this.herniPoles[0].postavy.Add(hero);
        this.herniPoles[0].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[1].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[2].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[2].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[3].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[3].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[3].postavy.Add(tvurceKostlivec.FactoryMethod());
        this.herniPoles[4].postavy.Add(tvurceKostlivec.FactoryMethod());
        this.herniPoles[5].postavy.Add(tvurceKostlivec.FactoryMethod());
        this.herniPoles[5].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[6].postavy.Add(tvurceKostlivec.FactoryMethod());
        this.herniPoles[6].postavy.Add(tvurceKostlivec.FactoryMethod());
        this.herniPoles[6].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[7].postavy.Add(tvurceKostlivec.FactoryMethod());
        this.herniPoles[7].postavy.Add(tvurceKostlivec.FactoryMethod());
        this.herniPoles[7].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[8].postavy.Add(tvurceKostlivec.FactoryMethod());
        this.herniPoles[8].postavy.Add(tvurceKostlivec.FactoryMethod());
        this.herniPoles[8].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[8].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[8].postavy.Add(tvurceVlk.FactoryMethod());
        this.herniPoles[9].postavy.Add(tvurceBoss.FactoryMethod());




    }

}
}