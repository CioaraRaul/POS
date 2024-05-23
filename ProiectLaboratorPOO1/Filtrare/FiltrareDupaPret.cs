using Entitati;
using ProiectLaboratorPOO1.Criteriu;

namespace ProiectLaboratorPOO1.Filtrare
{
    internal class FiltrareDupaPret : IFiltrare
    {
        public List<ProdusAbstract> Filtrare(List<ProdusAbstract> produse, ICriteriu criteriu)
        {
            if (criteriu is CriteriuPret)  // Check if criteriu is of type CriteriuPret
            {
                CriteriuPret pretCriteriu = (CriteriuPret)criteriu;  // Cast to CriteriuPret
                List<ProdusAbstract> rezultate = new List<ProdusAbstract>();
                foreach (ProdusAbstract produs in produse)
                {
                    if (pretCriteriu.IsIndeplinit(produs))  // Use CriteriuPret's IsIndeplinit
                    {
                        rezultate.Add(produs);
                    }
                }
                return rezultate;
            }
            else
            {
                throw new ArgumentException("Criteriul trebuie sa fie de tipul CriteriuPret");
                // You can also return an empty list here if the criteria is not compatible
            }
        }
    }
}
