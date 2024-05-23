using Entitati;
using ProiectLaboratorPOO1.Criteriu;
using ProiectLaboratorPOO1.Filtrare;

namespace ProiectLaboratorPOO1
{
    public abstract class ProdusAbstractMgr
    {
        public List<ProdusAbstract> elemente = new List<ProdusAbstract>();
        //public int CountElemente { get; set; } = 0;
        public int Id { get; set; } = 0;

        public void Write2Console()
        {
            foreach (ProdusAbstract elem in elemente)
            {
                Console.WriteLine(elem.ToString());
                //redefineste toString
            }
        }

        protected bool VerifyUnicity(ProdusAbstract item)
        {
            foreach (ProdusAbstract elem in elemente)
            {
                if (elem.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void ReadAbsProd(ProdusAbstract item)
        {
            if (!elemente.Contains(item))
            {
                elemente.Add(item);
                //CountElemente+=1; 
                Id++;
            }
        }

        public bool Contine(ProdusAbstract item)
        {
            return VerifyUnicity(item);
        }

        public List<ProdusAbstract> Contine(String nume)
        {
            List<ProdusAbstract> rezultate = new List<ProdusAbstract>();
            foreach (ProdusAbstract elem in elemente)
            {
                if (elem.Name == nume)
                {
                    rezultate.Add(elem);

                }
            }
            return rezultate;
        }

        public void CautaDupaNume()
        {
            Console.WriteLine("Introdu numele produsului");
            string nume = Console.ReadLine();
            IEnumerable<ProdusAbstract> interogare_linq =
            from elem in elemente
            where elem.Name == nume
            select elem;
            foreach (ProdusAbstract elem in interogare_linq)
            {
                Console.WriteLine(elem.ToString());
            }
        }

        public void Sortare()
        {
            elemente.Sort((first, second) =>
            {
                if (first != null && second != null)
                    return first.Pret.CompareTo(second.Pret);

                if (first == null && second == null)
                    return 0;

                if (first != null)
                    return -1;

                return 1;
            });
        }

        public void afisare()
        {

            foreach (ProdusAbstract e in elemente)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void FiltrareDupaCategorieProd()
        {
            string? cat = Console.ReadLine();
            CriteriuCategorie criteriu = new CriteriuCategorie(cat);
            FIltrareDupaCategorie filtru = new FIltrareDupaCategorie();
            List<ProdusAbstract> rez = filtru.Filtrare(elemente, criteriu);
            if (rez.Any())
            {
                foreach(ProdusAbstract elem in rez)
                {
                    Console.WriteLine(elem.ToString() );
                }
            }

        }

        public void FiltrareDupaPretProd()
        {
            int prt = int.Parse(Console.ReadLine() ?? string.Empty);
            CriteriuPret criteriu = new CriteriuPret(prt);
            FiltrareDupaPret filtru = new FiltrareDupaPret();
            List<ProdusAbstract> rez = filtru.Filtrare(elemente, criteriu);
            if (rez.Any())
            {
                foreach (ProdusAbstract elem in rez)
                {
                    Console.WriteLine(elem.ToString());
                }
            }

        }

    }
}
