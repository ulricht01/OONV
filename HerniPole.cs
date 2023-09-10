using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OONV_Seminarka
{
    public class HerniPole
{
    public int cislo_pole;
    public List<Postava> postavy;
    public HerniPole(int cislo_pole)
    {
        this.cislo_pole = cislo_pole;
        postavy = new List<Postava>();
    }

    public void pridej_postavu(Postava postava)
    {
        postavy.Add(postava);
    }

    public void odeber_postavu(Postava postava)
    {
        postavy.Remove(postava);
    }
}
}