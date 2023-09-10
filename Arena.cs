using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OONV_Seminarka
{
    public interface IArenaObserver
{
    void update();
}

public class Arena
{
    private List<IArenaObserver> observers = new List<IArenaObserver>();
    private bool finished;
    public Arena()
    {
        this.finished = false;
    }

    public void pridej_divaka(IArenaObserver observer)
    {
        observers.Add(observer);
    }

    public void odpal_divaka(IArenaObserver observer)
    {
        observers.Remove(observer);
    }

    public void upozorneni()
    {
        foreach (IArenaObserver observer in observers)
        {
            observer.update();
        }
    }

    public void odstartuj_hru()
    {
        HraciPlocha hraciPlocha = HraciPlocha.get_instance();
        Hrdina hero = Hrdina.getInstance();
        hraciPlocha.priprav_hru(hero);
        this.pridej_divaka(hero);

        foreach (HerniPole herniPole in hraciPlocha.herniPoles)
        {
          this.zahaj_boj(hero, hraciPlocha); 
          if (hero.akt_pozice < hraciPlocha.herniPoles.Count-1) 
          {
          hero.pohyb_dopredu(hraciPlocha);
          }
        }
        this.konec_hry();
    }

    private void konec_hry()
    {
        this.finished = true;
        System.Console.WriteLine("Gratuluji hrdino, dokončil jsi svou misi!");
        Console.ReadKey();
        Environment.Exit(0);
    }

    public void zahaj_boj(Hrdina hrdina, HraciPlocha hraciPlocha)
    {
        Random random = new Random();
        HerniPole aktPole = hraciPlocha.herniPoles[hrdina.akt_pozice];
        List<Postava> nepratele = aktPole.postavy.FindAll(postava => postava is not Hrdina);
        List<Postava> mrtviNepratele = new List<Postava>();
        nepratele.RemoveAll(postava => postava.alive == false);
        
        if (nepratele.Count > 0)
        {
            System.Console.WriteLine("===== Boj začíná: =====");
            while (hrdina.alive == true & nepratele.Count > 0)
            {
                int cislo = random.Next(0, nepratele.Count);   

                System.Console.WriteLine($"Zdraví {hrdina.GetType().Name}: {hrdina.health}");

                hrdina.utok(nepratele[cislo]); 

                foreach (Postava nepritel in nepratele)
                {
                    System.Console.WriteLine($"Zdraví {nepritel.GetType().Name}: {nepritel.health}");
                    if (nepritel.alive == true)
                    {
                        nepritel.utok(hrdina);
                    }
                    if (nepritel.alive == false)
                    {
                        hrdina.get_zkusenosti(nepritel);
                    }
                }

                nepratele.RemoveAll(postava => postava.alive == false);
                System.Console.WriteLine("");
                System.Console.WriteLine("===== Konec kola =====");
                System.Console.WriteLine("");
            }
            if (hrdina.alive == false)
            {
                System.Console.WriteLine("Hrdina umřel!");
                Environment.Exit(0);
            }
        }
        System.Console.WriteLine($"Pole {hrdina.akt_pozice+1} je vyčistěno!");
        upozorneni();
        hraciPlocha.vykresli_desku();
        Console.ReadKey();
    }
}
}