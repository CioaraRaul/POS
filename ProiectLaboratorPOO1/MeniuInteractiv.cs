using Entitati;
using System.ComponentModel;

namespace ProiectLaboratorPOO1
{
    internal class MeniuInteractiv
    {
        ProduseMgr prod = new ProduseMgr();
        ServiciiMgr serv = new ServiciiMgr();
        Pachet pachetOriginal = new Pachet();
        PachetMgr pachetMgr = new PachetMgr();
        int noOfPcK;
        public void Menu()
        {

            Console.WriteLine("Salut! Ne bucuram ca ai ales programul nostru pentru organizarea pachetelor tale.");
            Console.WriteLine("Cu ce te putem ajuta azi?");
            int op;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                optiuniMeniu();
                Console.Write("Alege o optiune: ");
                op = int.Parse(Console.ReadLine() ?? string.Empty);
                Console.ForegroundColor = ConsoleColor.Gray;
                actiuniMeniu(op);
            } while (op != 0);
        }
        private void optiuniMeniu()
        {
            Console.WriteLine("0. Inchide programul");
            Console.WriteLine("1. Actualizeaza setarile");
            Console.WriteLine("2. Adauga pachete de la tastatura");
            Console.WriteLine("3. Afiseaza pachetele");
            Console.WriteLine("4. Incarca pachetele din xml");
            Console.WriteLine("5. Filtrare dupa categorie");
            Console.WriteLine("6. Filtrare dupa pret");
        }
        private void actiuniMeniu(int n)
        {
            switch (n)
            {
                case 0:
                    Console.WriteLine("Multumim ca ati ales programul nostru.");
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Seteaza numarul de produse si servicii");
                    pachetOriginal.setTheNumberOfProducts();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Introdu Pachete");
                    Console.Write("cate Pachete introduci: ");
                    int number = int.Parse(Console.ReadLine() ?? string.Empty);
                    pachetMgr.readPachet(number);
                    pachetMgr.Sortare();
                    break;
                case 3:
                    Console.Clear();
                    pachetMgr.afis();
                    break;
                case 4:
                    Console.Clear();
                    pachetMgr.InitListafromXML();
                    pachetMgr.Sortare();
                    Console.WriteLine("Incarcarea a avut loc cu succes!");
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Introdu categoria dorita: ");
                    pachetMgr.FiltrareDupaCategorieProd();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Introdu filtrul de pret: ");
                    pachetMgr.FiltrareDupaPretProd();
                    break;
                case 7:
                    Console.Clear();
                    Console.Write("Cate pachete vrei sa serializazi: ");
                    noOfPcK = int.Parse(Console.ReadLine() ?? string.Empty);
                    pachetMgr.dataSerialization(noOfPcK);
                    break;
                case 8:
                    Console.Clear();
                    pachetMgr.dataDeserialization();
                    Console.WriteLine("Deserializarea a avut loc cu succes");
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Nu avem optiunea solicitata!");

                    break;
            }
        }

    }
}
