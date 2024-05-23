using Entitati;
using System.Xml;

namespace ProiectLaboratorPOO1
{
    public class ServiciiMgr : ProdusAbstractMgr
    {
        internal Serviciu userInputData(int id)
        {
            string? nume;
            string? codIntern;
            string? categorie;
            int pret;

            Console.WriteLine("Introdu un Serviciu");
            Console.Write("Numele:");
            nume = Console.ReadLine();

            Console.Write("Codul intern:");
            codIntern = Console.ReadLine();

            Console.WriteLine("Categoria: ");
            categorie = Console.ReadLine();

            Console.WriteLine("Pret: ");
            pret = int.Parse(Console.ReadLine() ?? string.Empty);

            return new Serviciu(id, nume, codIntern, categorie, pret);
        }

        public void ReadAbsProds(int number)
        {
            Serviciu serviciu;

            for (int i = 0; i < number; i++)
            {
                serviciu = userInputData(Id);
                
                ReadAbsProd(serviciu);
            }
        }

        public void InitListafromXML()
        {
            //initializare lista dintr-un fisier XML
            XmlDocument doc = new XmlDocument();
            //incarca fisierul
            doc.Load("C:\\All folder\\C# POO\\POS\\ProiectLaboratorPOO1\\XML\\produse.xml"); //calea spre fisier
                                                                                             //selecteaza nodurile
            XmlNodeList lista_noduri = doc.SelectNodes("/produse/serviciu");

            foreach (XmlNode nod in lista_noduri)
            {
                //itereaza si selecteaza simpurile fiecarui nod si
                //informatia continuta in cadrul proprietatii InnerText
                string nume = nod["Nume"].InnerText;
                string codIntern = nod["CodIntern"].InnerText;
                int pret = int.Parse(nod["Pret"].InnerText);
                string categorie = nod["Categorie"].InnerText;
                //adauga in lista produse
                elemente.Add(new Serviciu(elemente.Count + 1, nume, codIntern, categorie, pret));
            }
        }

        /*public void Exista()
        {
            Console.WriteLine("Cauta un produs dupa toata descrierea sa: ");

            Serviciu serv = userInputData(-1);
            if (Contine(serv))
                Console.WriteLine("Am gasit produsul in lista de produse");
            else Console.WriteLine("Acest produs nu exista in lista noastra de produse");
        }*/

        /*public void afisareXML()
        {
            Serviciu serviciu = userInputData(-1);
            serviciu.save2XML("ServiciiSerializate");
            Serviciu? altserviciu = serviciu.loadFromXML("ServiciiSerializate");
            Console.WriteLine(altserviciu.ToString());
        }*/
    }
}
