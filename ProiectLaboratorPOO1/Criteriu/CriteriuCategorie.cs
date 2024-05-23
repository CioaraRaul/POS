using Entitati;

namespace ProiectLaboratorPOO1.Criteriu
{
    internal class CriteriuCategorie : ICriteriu
    {
        public string? Categorie { get; set; }

        public CriteriuCategorie(string categorie)
        {
            Categorie = categorie;
        }
        public bool IsIndeplinit(ProdusAbstract produs)
        {
            return produs.Categorie == Categorie; // verifica daca categoria produsului se potriveste
        }
    }
}
