using Entitati;
using System.Xml;
using System.Xml.Linq;

namespace ProiectLaboratorPOO1
{
    internal class PachetMgr : ProdusAbstractMgr
    {
        public int IdP { get; set; } = 0;

        private Pachet userInputData()
        {
            string? nume;
            string? codIntern;
            string? categorie;
            int pret = 0;
            
            
            Console.WriteLine("Introdu un pachet");
            Console.Write("Numele:");
            nume = Console.ReadLine();

            Console.Write("Codul intern:");
            codIntern = Console.ReadLine();

            Console.WriteLine("Categoria: ");
            categorie = Console.ReadLine();

            Pachet pch=new Pachet();
            IdP++;
            List<ProdusAbstract> prodServ = ReadProdServ();
            foreach(ProdusAbstract ps in prodServ)
            {
                pch.Elemente_pachet.Add(ps);
            }
            
            
            foreach(ProdusAbstract p in pch.Elemente_pachet)
            {
                pret = pret + p.Pret;
            }
            pch.Pret = pret;
            pch.CodIntern = codIntern;
            pch.Categorie = categorie;
            pch.Name = nume;

            return pch;
        }
        public List<ProdusAbstract> ReadProdServ()
        {
            Pachet pch = new Pachet();
            List<ProdusAbstract> listaProduseServicii = new List<ProdusAbstract>();
            ProduseMgr prodmgr = new ProduseMgr();
            ServiciiMgr servmgr = new ServiciiMgr();

            // Read the XML file into a string
            string xmlContent = File.ReadAllText("C:\\All folder\\C# POO\\POS\\ProiectLaboratorPOO1\\XML\\setting.xml");

            // Parse the XML string into an XDocument
            XDocument xmlDoc = XDocument.Parse(xmlContent);

            // Get the values of the first two elements in the XML file
            int prodNumber = int.Parse(xmlDoc.Root.Elements().First().Value);
            int servNumber = int.Parse(xmlDoc.Root.Elements().ElementAt(1).Value);

            // Create the necessary number of Produs and Serviciu objects and add them to the Pachet object
            for (int i = 0; i < prodNumber; i++)
            {
                Produs prod = prodmgr.userInputData(Id);
                listaProduseServicii.Add(prod);
                Id++;
            }

            for (int i = 0; i < servNumber; i++)
            {
                Serviciu serv = servmgr.userInputData(Id);
                
                    listaProduseServicii.Add(serv);
                    Id++;
            }
            
            return listaProduseServicii;
        }

        public void readPachet(int number)
        {
            for (int i = 0; i < number; i++)
            {
                elemente.Add(userInputData());
            }
        }

        public void afis()
        {
            foreach (Pachet pachet in elemente)
            {
                Console.WriteLine(pachet.ToString());
            }
        }

        public void InitListafromXML()
        {
            //initializare lista dintr-un fisier XML
            XmlDocument doc = new XmlDocument();
            //incarca fisierul

            doc.Load("C:\\All folder\\C# POO\\POS\\ProiectLaboratorPOO1\\XML\\Pachete.xml"); //calea spre fisier
                                                                                             //selecteaza nodurile
            XmlNodeList lista_noduri = doc.SelectNodes("/pachete/pachet/infoPach");
            foreach (XmlNode nod in lista_noduri)
            {
                Pachet pachet = new Pachet();
                int pret = 0;
                pachet.Name = nod["nume"].InnerText;
                pachet.CodIntern = nod["codIntern"].InnerText;
                pachet.Categorie = nod["categorie"].InnerText;
                XmlNodeList lista_prod = nod.SelectNodes("../produs");
                foreach (XmlNode nodp in lista_prod)
                {
                    string nume = nodp["nume"].InnerText;
                    string codIntern = nodp["codIntern"].InnerText;
                    string producator = nodp["producator"].InnerText;
                    int pretp = int.Parse(nodp["pret"].InnerText);
                    string categorie = nodp["categorie"].InnerText;
                    pret = pret + pretp;
                    //adauga in lista produse
                    pachet.Elemente_pachet.Add(new Produs(Id, nume, codIntern, producator, categorie, pretp));
                    Id++;
                }

                XmlNodeList lista_serv = nod.SelectNodes("../serviciu");
                foreach (XmlNode nodS in lista_serv)
                {
                    //itereaza si selecteaza simpurile fiecarui nod si
                    //informatia continuta in cadrul proprietatii InnerText
                    string nume = nodS["nume"].InnerText;
                    string codIntern = nodS["codIntern"].InnerText;
                    int pretS = int.Parse(nodS["pret"].InnerText);
                    string categorie = nodS["categorie"].InnerText;
                    pret = pret + pretS;
                    //adauga in lista produse
                    pachet.Elemente_pachet.Add(new Serviciu(Id, nume, codIntern, categorie, pretS));
                    Id++;
                }
                pachet.Pret = pret;
                elemente.Add(pachet);
            }
        }

        //salvare in XML & Salvare in lista elemente
        public void dataSerialization(int noOfPackages)
        {
            Pachet pch = new Pachet();
            List<Pachet> lPachete = new List<Pachet>();
            for (int i = 0; i < noOfPackages; i++)
            {
                Pachet pachet = userInputData();
                lPachete.Add(pachet);
            }
            pch.saveListToXML(lPachete, "XML_Pachete");
        }

        public void dataDeserialization()
        {
            Pachet pch = new Pachet();
            elemente.AddRange(pch.loadFromXML("XML_Pachete"));
        }
    }


}
