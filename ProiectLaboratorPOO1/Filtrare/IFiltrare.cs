using Entitati;
using ProiectLaboratorPOO1.Criteriu;

namespace ProiectLaboratorPOO1.Filtrare
{
    internal interface IFiltrare
    {
        List<ProdusAbstract> Filtrare(List<ProdusAbstract> elem, ICriteriu criteriu);
    }
}
