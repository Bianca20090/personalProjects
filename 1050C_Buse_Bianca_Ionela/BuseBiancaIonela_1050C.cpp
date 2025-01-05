#include<iostream>
#include<string>
#include<fstream>
#include<vector>
#include<set>
#include<map>
#include<algorithm>
using namespace std;


class Exceptie
{
	string mesajExceptie;

public:
	Exceptie()
	{
		this->mesajExceptie = "Eroare!";
	}

	Exceptie(string mesajExceptie)
	{
		this->mesajExceptie = mesajExceptie;
	}

	string getMesajExceptie()
	{
		return mesajExceptie;
	}

	void setmesajExceptie(string mesajExceptieNou)
	{
		if (mesajExceptieNou.size() >= 3)
		{
			mesajExceptie = mesajExceptieNou;
		}

	}
};

string getMonthName(int monthNumber)
{
	string months[] = { "January", "February", "March",
					   "April", "May", "June",
					   "July", "August", "September",
					   "October", "November", "December"
	};

	return (months[monthNumber]);
}

enum CutieDeViteze { Automata, Manuala };

struct StatusPeZi {
	string zi;
	bool inchirat;
};

class Masina {
	char* model;
	int nrLocuri;
	int anFabricatie;
	StatusPeZi status[365];
	CutieDeViteze tipCDV;
	float pret;



public:


	Masina()
	{
		this->model = new char[strlen("Necunoscut") + 1];
		strcpy(this->model, "Necunoscut");
		this->nrLocuri = 0;
		this->tipCDV = Manuala;
		this->anFabricatie = 0;
		this->pret = 0;
		string zi;
		ifstream theFile("calendarPOO.txt");
		if (theFile)
		{
			for (int i = 0; getline(theFile, zi); i++)
			{
				status[i].zi = zi;
				status[i].inchirat = false;
			}
		}
		theFile.close();
	}


	Masina(const char* model, int nrLocuri, CutieDeViteze tipCDV, int AnFabricatie, float pret)
	{
		if (strlen(model) > 2)
		{
			this->model = new char[strlen(model) + 1];
			strcpy(this->model, model);

		}
		else {
			this->model = new char[strlen("Necunoscut") + 1];
			strcpy(this->model, "Necunoscut");
		}

		if (nrLocuri > 0)
		{
			this->nrLocuri = nrLocuri;

		}
		else
		{
			this->nrLocuri = 0;

		}

		if (anFabricatie > 0)
		{
			this->anFabricatie = AnFabricatie;

		}
		else
		{
			this->anFabricatie = 0;

		}

		this->tipCDV = tipCDV;
		this->anFabricatie = AnFabricatie;
		if (pret != 0)
		{
			this->pret = pret;

		}
		else {
			this->pret = 0;
		}

		string zi;
		ifstream theFile("calendarPOO.txt");
		if (theFile)
		{
			for (int i = 0; getline(theFile, zi); i++)
			{
				status[i].zi = zi;
				status[i].inchirat = false;

			}
		}
		theFile.close();

	}

	Masina(const char* model, int nrLocuri)
	{

		this->model = new char[strlen(model) + 1];
		strcpy(this->model, model);
		this->nrLocuri = nrLocuri;
		this->tipCDV = Manuala;
		this->anFabricatie = 0;
		this->pret = 0;
		string zi;
		ifstream theFile("calendarPOO.txt");
		if (theFile)
		{
			for (int i = 0; getline(theFile, zi); i++)
			{
				status[i].zi = zi;
				status[i].inchirat = false;

			}
		}
		theFile.close();

	}


	friend ostream& operator<<(ostream& out, Masina m)
	{
		out << "Model: " << m.model << endl;
		out << "Nr Locuri: " << m.nrLocuri << endl;
		out << "Cutie de Viteze: ";
		switch (m.tipCDV)
		{
		case 0:
			out << "Automata";
			break;
		case 1:
			out << "Manuala";
			break;
		default:
			out << "Manuala";
			break;

		}
		out << "\n";
		out << "An fabricatie: " << m.anFabricatie << endl;
		out << "Pret/zi ($): " << m.pret << endl;
		for (int i = 0; i < 365; i++)
		{
			out << "\nZiua: " << m.status[i].zi;
			out << "\nInchiriata?" << (m.status[i].inchirat ? "Da" : "Nu") << endl;
		}

		return out;
	}

	friend istream& operator>>(istream& in, Masina& m)
	{

		if (m.model != NULL)
		{
			delete[] m.model;
		}
		cout << "Modelul masinii: ";
		char aux[200];
		in >> ws;
		in.getline(aux, 199);
		m.model = new char[strlen(aux) + 1];
		strcpy(m.model, aux);

		cout << "Numar de Locuri: ";
		in >> m.nrLocuri;
		cout << "An Fabricatie: ";
		in >> m.anFabricatie;
		cout << "Pret: ";
		in >> m.pret;

		cout << "Cutie de Viteze: ";
		string ctv;
		in >> ws;
		getline(in, ctv);
		if (ctv == "Automata")
		{
			m.tipCDV = Automata;
		}
		else if (ctv == "Manuala")
		{
			m.tipCDV = Manuala;
		}

		return in;
	}

	Masina(const Masina& m)
	{

		this->model = new char[strlen(m.model) + 1];
		strcpy(this->model, m.model);
		this->nrLocuri = m.nrLocuri;
		this->tipCDV = m.tipCDV;
		this->anFabricatie = m.anFabricatie;
		this->pret = m.pret;
		string zi;
		ifstream theFile("calendarPOO.txt");
		if (theFile)
		{
			for (int i = 0; getline(theFile, zi); i++)
			{
				status[i].zi = zi;
				status[i].inchirat = false;

			}
		}
		theFile.close();


	}


	Masina operator=(const Masina& m)
	{
		if (this != &m)
		{
			if (this->model != NULL)
			{
				delete[] this->model;
			}

			this->model = new char[strlen(m.model) + 1];
			strcpy(this->model, m.model);
			this->nrLocuri = m.nrLocuri;
			this->tipCDV = m.tipCDV;
			this->anFabricatie = m.anFabricatie;
			this->pret = m.pret;
			string zi;
			ifstream theFile("calendarPOO.txt");
			if (theFile)
			{
				for (int i = 0; getline(theFile, zi); i++)
				{
					status[i].zi = zi;
					status[i].inchirat = false;

				}
			}
			theFile.close();

			return *this;
		}
	}

	friend ofstream& operator<<(ofstream& out, Masina m)
	{
		out << m.model << endl;
		out << m.nrLocuri << endl;
		switch (m.tipCDV)
		{
		case 0:
			out << "Automata";
			break;
		case 1:
			out << "Manuala";
			break;
		default:
			out << "Manuala";
			break;

		}
		out << "\n";
		out << m.anFabricatie << endl;
		out << m.pret << endl;
		for (int i = 0; i < 365; i++)
		{
			out << m.status[i].zi << endl;
			out << (m.status[i].inchirat ? "Da" : "Nu") << endl;
		}

		return out;
	}

	friend ifstream& operator>>(ifstream& in, Masina& m)
	{

		if (m.model != NULL)
		{
			delete[] m.model;
		}

		char aux[200];
		in >> ws;
		in.getline(aux, 199);
		m.model = new char[strlen(aux) + 1];
		strcpy(m.model, aux);
		in >> m.nrLocuri;
		in >> m.anFabricatie;
		in >> m.pret;
		string ctv;
		in >> ws;
		getline(in, ctv);
		if (ctv == "Automata")
		{
			m.tipCDV = Automata;
		}
		else if (ctv == "Manuala")
		{
			m.tipCDV = Manuala;
		}

		return in;
	}

	bool InchiriereMasina(string dataInchiriere, int zileInchiriate)
	{


		if (zileInchiriate > 0)
		{

			int i = 0;
			while (status[i].zi != dataInchiriere)
			{
				i++;
			}
			for (int j = i; j < i + zileInchiriate; j++)
			{

				if (status[j].inchirat == true)
					return false;

			}
			for (int j = i; j < i + zileInchiriate; j++)
			{

				status[j].inchirat = true;

			}

			return true;
		}

	}

	int TotalInchirieriMasina()
	{
		int nr = 0;
		int i = 0;
		for (int i = 0; i < 365; i++)
		{
			if (status[i].inchirat != false)
			{
				nr++;

			}
		}
		return nr;
	}

	//model
	char* getModel()
	{
		return model;
	}

	void setModel(const char* ModelNou)
	{
		if (strlen(ModelNou) > 1)
		{
			delete[] this->model;
			this->model = new char[strlen(ModelNou) + 1];
			strcpy(this->model, ModelNou);

		}
		else
		{
			cout<<"Numele este prea mic!"<<endl;
		}
	}

	//int nr locuri

	int getNrLocuri()
	{
		return nrLocuri;
	}

	void setNrLocuri(int nrlocurinou)
	{
		if (nrlocurinou >= 2 && nrlocurinou <= 8)
		{
			nrLocuri = nrlocurinou;

		}
		else
		{
			cout<<"Numarul de locuri este prea mic sau mult prea mare pentru o masina!"<<endl;
		}

	}

	//int anFabricatie
	// 
	int getAnFabricatie()
	{
		return anFabricatie;
	}

	void setAnFab(int anFabNou)
	{
		anFabricatie = anFabNou;
	}

	//bool curiedeviteze -CutieDeViteze tipCDV

	CutieDeViteze getTipcutie()
	{
		return tipCDV;
	}

	void setTipCutie(CutieDeViteze tipCDVnou)
	{
		tipCDV = tipCDVnou;
	}


	//floatpret
	float getPret()
	{
		return pret;
	}

	void setPretMasina(int pretNou)
	{
		if (pretNou > 0.0)
		{
			pret = pretNou;
		}
		else
		{
			throw Exceptie("Pretul de inchiriere este necorespunzator.");
		}

	}

	void printeazaCalendar() {
		int days;
		int lastIndexInMyCalendar = 0;


		for (int i = 0; i < 11; i++)
		{
			string lunaCurenta = status[lastIndexInMyCalendar].zi.substr(3, 2);
			int zileInLunaCurenta = 1;
			int index = lastIndexInMyCalendar + 1;

			while (lunaCurenta == status[index].zi.substr(3, 2)) {
				zileInLunaCurenta++;
				index++;
			}

			printf("\n  ------------%s-------------\n",
				getMonthName(i).c_str());

			int k = 0;

			for (int j = lastIndexInMyCalendar; j < (lastIndexInMyCalendar + zileInLunaCurenta); j++)
			{

				if (status[j].inchirat == false) {
					cout << status[j].zi.substr(0, 2) << " ";
				}
				else {
					printf("x  ");
				}

				if (++k > 6)
				{
					k = 0;
					printf("\n");
				}
			}

			lastIndexInMyCalendar += zileInLunaCurenta;

			if (k)
				printf("\n");

		}
	}

	void scrieInFBinar(fstream& fisier)
	{
		int lungime = strlen(this->model);
		fisier.write((char*)&lungime, sizeof(int));

		for (int i = 0; i < lungime; i++)
		{
			fisier.write((char*)&this->model[i], sizeof(char));
			fisier.write((char*)&this->status[i].zi, sizeof(string));
			fisier.write((char*)&this->status[i].inchirat, sizeof(bool));

		}
		fisier.write((char*)&this->nrLocuri, sizeof(int));
		fisier.write((char*)&this->anFabricatie, sizeof(int));
		fisier.write((char*)&this->tipCDV, sizeof(CutieDeViteze));
		fisier.write((char*)&this->pret, sizeof(float));

	}
		

		void citesteDinFisierBinar(fstream& fisier) {

			int lungime = 0;
			fisier.read((char*)&lungime, sizeof(int));
			if (this->model != NULL)
			{
				delete[] this->model;
			}
			this->model = new char[lungime + 1];
			for (int i = 0; i < lungime; i++)
			{
				fisier.read((char*)&this->model[i], sizeof(char));
				fisier.read((char*)&this->status[i].zi, sizeof(string));
				fisier.read((char*)&this->status[i].inchirat, sizeof(bool));
			}

			this->model[lungime] = '\0';
			fisier.read((char*)&this->nrLocuri, sizeof(int));
			fisier.read((char*)&this->anFabricatie, sizeof(int));
			fisier.read((char*)&this->tipCDV, sizeof(CutieDeViteze));
			fisier.read((char*)&this->pret, sizeof(float));


		}


	bool operator>(Masina m)
	{
		return this->pret > m.pret;

	}
	bool operator<(Masina m)
	{
		return this->pret < m.pret;

	}
	bool operator==(Masina m)
	{
		if (this->anFabricatie == m.anFabricatie)
		{
			return true;
		}
		else
		{
			return false;
		}

	}
	operator float()
	{
		return pret;
	}

	Masina operator+(Masina m)
	{
		Masina result = *this;
		result.pret = this->pret + m.pret;
		return result;
	}
	
	bool verificadata(string data)
	{
		int gasit = 0;
		for (int i = 0; i < 365; i++)
		{
		
			if (data == status[i].zi)
			{
				gasit = 1;
				break;
			}
		}
		if (gasit == 0)
		{
			return false;
		}
		return true;

	}


	bool operator<(const Masina& m)const
	{
		return this->pret < m.pret;

	}


	bool operator<(float an)
	{
		if (this->anFabricatie < an)
		{
			return true;
		}
		else
		{
			return false;
		}

	}


	~Masina()
	{
		if (model != NULL)
		{
			delete[] this->model;
		}
	}
};

template<typename tip>
bool comparaPret(tip a, tip b)
{
	return a > b;
}



class ParcAuto {

private:
	string numeParc;
	int nrMasini;
	Masina* masini;
	int nrAng;

	const int AnInfiintare;
	static int nrMinMasina;
public:
	ParcAuto() :AnInfiintare(2015)
	{
		numeParc = "Inchirieri AUTO";
		nrMasini = 2;
		nrAng = 4;
		masini = new Masina[2];

		masini[0].setModel("Kia Seltos");
		masini[0].setNrLocuri(5);
		masini[0].setAnFab(2020);
		masini[0].setTipCutie(Manuala);
		masini[0].setPretMasina(150);

		masini[1].setModel("Jeep Wrangler");
		masini[1].setNrLocuri(5);
		masini[1].setAnFab(2015);
		masini[1].setTipCutie(Manuala);
		masini[1].setPretMasina(125);


	}

	ParcAuto(const ParcAuto& pa) :AnInfiintare(2015)
	{
		numeParc = pa.numeParc;
		nrMasini = pa.nrMasini;
		masini = pa.masini;
		nrAng = pa.nrAng;

	}

	ParcAuto operator=(const ParcAuto& pa)
	{
		if (this != &pa)
		{
			if (masini != NULL)
			{
				delete[]this->masini;
			}

			numeParc = pa.numeParc;
			nrMasini = pa.nrMasini;
			masini = pa.masini;
			nrAng = pa.nrAng;

		}
		return *this;
	}

	Masina* getMasini()
	{
		return this->masini;
	}

	
	int getNrAng()
	{
		return this->nrAng;
	}

	void setNRAng(int nrAng)
	{
		this->nrAng = nrAng;
	}

	string getNumeParc()
	{
		return numeParc;
	}

	void setNumeParc(string numeParcAuto)
	{
		if (numeParcAuto.size() >= 3)
		{
			this->numeParc = numeParcAuto;
		}
	}

	static int getNRMINM()
	{
		return nrMinMasina;
	}

	friend ostream& operator<<(ostream& out, ParcAuto& pa)
	{
		out << endl << "Nume Parc Auto: " << pa.numeParc;
		out << endl << "Anul Infiintarii parcului auto: " << pa.AnInfiintare;
		out << endl << "Nr masini: " << pa.nrMasini;
		for (int i = 0; i < pa.nrMasini; i++)
		{
			out << endl << pa.masini[i];
		}
		out << endl << "Nr angajati: " << pa.nrAng;
		return out;
	}

	friend istream& operator>>(istream& in, ParcAuto& pa)
	{

		if (pa.masini != NULL)
		{
			delete[] pa.masini;
		}

		cout << "Nume Parc Auto: ";
		in >> ws;
		getline(in, pa.numeParc);
		cout << "Numar Masini: ";
		in >> pa.nrMasini;
		cout << "Numar de angajati: ";
		in >> pa.nrAng;


		return in;
	}


	ParcAuto operator+=(Masina m) {
		this->nrMasini++;
		Masina* aux = new Masina[nrMasini];
		if (this->masini != NULL) {
			for (int i = 0; i < nrMasini - 1; i++) {
				aux[i] = this->masini[i];
			}
			delete[]masini;
		}
		aux[nrMasini - 1] = m;
		masini = aux;
		return *this;
	}

	

	int nrTotalInchirieri()
	{
		int totInc = 0;

		for (int i = 0; i < nrMasini; i++)
		{
			totInc = totInc + masini[i].TotalInchirieriMasina();
		}

		return totInc;
	}



	int getNrTotalMasini() {
		return nrMasini;
	}

	void setMasini(int nrMasini, Masina* masini)
	{
		if (nrMasini >= 1 && masini != NULL)
		{
			this->nrMasini = nrMasini;
			for (int i = 0; i < this->nrMasini; i++)
			{
				this->masini[i] = masini[i];
			}

		}

	}


	const int getAnParc()
	{
		return AnInfiintare;
	}

	void MasinaExemple()
	{
		for (int i = 0; i < getNrTotalMasini(); i++)
		{
			cout << "Masina " << i << ":" << endl;
			cout << "Model:" << masini[i].getModel() << endl;
			cout << "Numar Locuri:" << masini[i].getNrLocuri() << endl;
			cout << "Tip Cutie Viteze:";
			switch (masini[i].getTipcutie())
			{
			case 0:
				cout << "Automata";
				break;
			case 1:
				cout << "Manuala";
				break;
			default:
				cout << "Manuala";
				break;

			}
			cout << endl;
			cout << "An Fabricatie:" << masini[i].getAnFabricatie() << endl;
			cout << "Pret/zi ($): " << masini[i].getPret() << endl;
			cout << endl;
		}
	}

	char* operator[](int pozitie)
	{
		if (pozitie >= 0 && pozitie < nrMasini)
		{
			return masini[pozitie].getModel();
		}
	
	}


	void statisticiOMasina(int idMasina) {
		cout << "Masina " << masini[idMasina].getModel() << " a fost inchiriata timp de: " << masini[idMasina].TotalInchirieriMasina() << " zile." << endl;
	}

	bool Inchiriere(int idMasina, string data, int nrzileinchirite)
	{
		return masini[idMasina].InchiriereMasina(data, nrzileinchirite);

	}

	Masina returnMasina(int idMasina)
	{
		return this->masini[idMasina];
	}

	void afisareCalend(int idMasina)
	{
		masini[idMasina].printeazaCalendar();
	}


	int getAnMasinaParc(int idMasina)
	{
		return masini[idMasina].getAnFabricatie();
	}
		
	string getModelCar(int idMasina)
	{
		return masini[idMasina].getModel();
	}

	

// datele sunt aceleasi pt toate masinile, deci se poate compara in fiecare caz cu datele trecute pt masina[0]

	bool verificamdata(string data)
	{
		return this->masini[0].verificadata(data);
	}

	ParcAuto operator++()
	{
		this->nrAng++;
		return *this;
	}

	ParcAuto operator++(int)
	{
		ParcAuto aux = *this;
		this->nrAng++;
		return aux;
	}

	ParcAuto operator+(int Valoare)
	{
		ParcAuto copie = *this;
		copie.nrAng = copie.nrAng + Valoare;
		return copie;

	}

	~ParcAuto()
	{
		/*if (this->masini != NULL)
		{
			for (int i = 0; i < this->nrMasini; i++)
			{
				delete masini[i];

			}
			delete[] masini;
		}*/

	}


};
int ParcAuto::nrMinMasina = 1;





void main()
{
	Masina m;
	Masina m2("Bmw M4", 5, Manuala, 2019, 100);
	Masina m3("Audi RS5", 5, Automata, 2020, 170);
	Masina m4("Brabus 900", 5, Automata, 2018, 250);
	Masina m6(m4);
	Masina m5;
	m5 = m3;
	
	ParcAuto parc;
	parc += m2;
	parc += m3;
	parc += m4;

	


	/*cout << "Printarea in fisier\n";
	ofstream f("DetaliiMasina.txt", ios::out);
	f << m2 << endl;
	f.close();

	Masina m7;
	cout << "Obiectul a fost scris in txt!" << endl;
	ifstream g("DetaliiMasina.txt", ios::in);
	if (g.is_open())
	{
		g >> m7;
		cout << "Obiectul a fost citit din txt!" << endl;
		g.close();
	}
	else {
		cout << "Fisierul nu exista!!\n";
	}

	cout << m7 << endl;*/

	/*	fstream outBin("fisier.dat", ios::out | ios::binary);
	m6.scrieInFBinar(outBin);
	outBin.close();
	cout << "S-a reusit scrierea!";

		fstream inBin("fisier.dat", ios::in | ios::binary);
	Masina m9;
	m9.citesteDinFisierBinar(inBin);
	cout << m9;
	inBin.close();*/


	//cout << "VectorMasina" << endl;
	vector<Masina>vectorMasina;
	vectorMasina.push_back(m);
	vectorMasina.push_back(m2);
	vectorMasina.push_back(m3);
	vectorMasina.push_back(m4);

	/*for (int i = 0; i < vectorMasina.size(); i++)
	{
		cout << vectorMasina[i] << endl;
	}*/


	set<Masina>setMasini;
	setMasini.insert(m);
	setMasini.insert(m2);
	setMasini.insert(m3);
	setMasini.insert(m4);

	set<Masina>::iterator it;
	/*for (it = setMasini.begin(); it != setMasini.end(); it++)
	{
		cout << *it << endl << endl;
	}*/

	map<int, Masina>mapMasina;
	mapMasina.insert(pair<int, Masina>(1, m));
	mapMasina.insert(pair<int, Masina>(20, m3));
	mapMasina.insert(pair<int, Masina>(15, m4));
	mapMasina.insert(pair<int, Masina>(2, m2));
	map<int,Masina>::iterator ite;
	/*for (ite = mapMasina.begin(); ite != mapMasina.end(); ite++)
	{
		cout << ite->first << endl << endl;
		cout << ite->second << endl << endl;
	}*/

	//cout << "STL sortat descrescator dupa pret" << endl;
	//sort(vectorMasina.begin(), vectorMasina.end(), comparaPret<Masina>);
	//for (int i = 0; i < vectorMasina.size(); i++)
	//{
	//	cout << vectorMasina[i] << endl;
	//}



	int optiune = 0;
	int nrMasiniParc = parc.getNrTotalMasini();
	string data;
	int zile;
	int optiuniOperatori = 0;

	while (optiune != 4) {
		switch (optiune)
		{
		case 0:
			cout << "Bine ati venit la Parcul Auto: " << parc.getNumeParc() << endl << endl;
			cout << "Alegeti una dintre urmatoarele optiuni:" << endl;
			cout << "1. Inchiriere masina" << endl;
			cout << "2. Afisare statistici Parc Auto" << endl;
			cout << "3. Afisarea operatiilor cu operatori" << endl;
			cout << "4. Exit" << endl;
			cin >> optiune;
			break;

		case 1:
			int optiuneMasina;
			cout << "Inchiriere masina" << endl;
			cout << "In parc avem urmatoarele Masini:" << endl;
			parc.MasinaExemple();

			cout << "Alegeti masina pe care doriti sa o inchiriati:";
			cin >> optiuneMasina;
			while (optiuneMasina < 0 || optiuneMasina > nrMasiniParc - 1) {
				cout << "Optiune gresita! Introduceti alt numar:";
				cin >> optiuneMasina;
			}

			cout << "Introduceti o data de inchiriere (dd/mm/yyyy) din anul 2023: ";
			cin >> data;
			while (parc.verificamdata(data) == false)
			{
				cout << "Data introdusa este gresita!\n";
				cout << "Introduceti data de inchiriere (dd/mm/yyyy): ";
				cin >> data;
			}


			cout << "Introduceti numarul de zile pentru care vreti sa inchiriati masina:";
			cin >> zile;
	

			if (parc.Inchiriere(optiuneMasina, data, zile) == false)
			{
				cout << "\nMasina nu a putut fi inchiriata! Aceasta a fost deja inchiriata in data respectiva.\n" << endl;
				string raspuns;
				cout << "Doriti sa vedeti calendarul cu inchirieri pentru masina aleasa?(Y/N)\n";
				cin >> raspuns;
				if (raspuns == "y" || raspuns == "Y")
				{
					cout << "Calendarul pentru masina " << optiuneMasina << ":" << endl;
					parc.afisareCalend(optiuneMasina);
					cout << endl;
				}

			}
			else {


				cout << "Calendarul pentru masina " << optiuneMasina << ":" << endl;
				parc.afisareCalend(optiuneMasina);
				cout << endl;
			}
			cout << "Alegeti o optiune:" << endl;
			cout << "0. Reveniti la meniul principal!" << endl;
			cout << "4. Exit" << endl;
			cin >> optiune;
			break;

			cout << endl;
			break;

		case 2:
			cout << "Afisare statistici" << endl;
			cout << "Statistici Parc: " << endl;
			cout << "Pe pacursul anului 2023, parcul auto a inregistrat, in total, un numar de " << parc.nrTotalInchirieri() << " zile, in care masinile au fost inchiriate.\n";

			cout << "Statistici masini: " << endl;
			for (int i = 0; i < parc.getNrTotalMasini(); i++)
			{
				parc.statisticiOMasina(i);

			}
			cout << endl;

			cout << "Alegeti o optiune:" << endl;
			cout << "0. Reveniti la meniul principal!" << endl;
			cout << "4. Exit" << endl;
			cin >> optiune;
			break;

		case 3:

			while (optiuniOperatori != 3)
			{
				if (optiuniOperatori == 0) {
					cout << "Alegeti la nivelul carei clase doriti sa vedeti supraincarcarea de operatori:\n";
					cout << "1. Clasa Parc Auto\n2. Clasa Masina\n3. Reveniti la meniul principal\n";
					cin >> optiuniOperatori;
				}
				else if (optiuniOperatori == 1)
				{
					cout << "Mai jos am utilizat operatorii: [], ++ (post si preincrementare) si +" << endl;
					cout << "1) OPERATORUL []: \nIn " << parc.getNumeParc() << " avem " << parc.getNrTotalMasini() << " masini\n";
					int pozitie;
					cout << "Introduceti pozitia de la care doriti sa vedeti modelul/denumirea masinii: ";
					cin >> pozitie;
					while (pozitie >= parc.getNrTotalMasini() || pozitie < 0)
					{
						cout << "Optiune gresita! Introduceti alt numar:";
						cin >> pozitie;
					}
					cout << "\nMasina de pe pozitia " << pozitie << " se numeste: ";
					cout << parc[pozitie] << endl << endl;
					cout << "2) Operatorul ++ pentru numarul de angajati:\nIn cadrul parcului auto, avem "<< parc.getNrAng()<< " angajati.\n";
					cout << "2.1) Rezultat postincrementare:" << parc.getNrAng()<<endl;
					parc++;
					++parc;
					cout <<"2.2) Rezultat preincrementare: "<< parc.getNrAng();
					int valoare;
					cout << "\n3) Operatorul +:\nIntroduceti un nr nou de angajati, pe care sa-l adaugam la nr actual de angajati: ";
					cin >> valoare;
					cout << "\nNoul nr de angajati este: " << (parc + valoare).getNrAng() <<endl<<endl;

					optiuniOperatori = 0;
				}
				else if (optiuniOperatori == 2)
				{
					cout << "Mai jos am utilizat operatorii: >, <, ==, +:" << endl;
					cout << "\nIn parc avem urmatoarele Masini:" << endl;
					parc.MasinaExemple();
					int car1;
					cout << "Alegeti o masina:\n";
					cin >> car1;
					while (car1 < 0 || car1 > nrMasiniParc - 1) {
						cout << "Optiune gresita! Introduceti alta masina:";
						cin >> car1;
					}
					int car2;
					cout << "Alegeti o a doua masina:" << endl;
					cin >> car2;
					while (car2 < 0 || car2 > nrMasiniParc - 1 || car1 == car2) {
						cout << "Optiune gresita! Introduceti alta masina:";
						cin >> car2;
					}
					cout << "Am comparat pretul/zi al celor doua masini alese" << endl;
					if (parc.returnMasina(car1) > parc.returnMasina(car2))
					{
						cout << "Masina " << parc.getModelCar(car1) << " are un pret mai mare decat masina " << parc.getModelCar(car2) << "." << endl;
					}
					else if(parc.returnMasina(car1) < parc.returnMasina(car2))
					{
						cout << "Masina " << parc.getModelCar(car1) << " are un pret mai mic decat masina " << parc.getModelCar(car2) << "." << endl;
					}
					else 
					{
						if (parc.returnMasina(car1) == parc.returnMasina(car2))
						{
							cout << "Masina " << parc.getModelCar(car1) << " are acelasi pret ca masina " << parc.getModelCar(car2) <<"."<< endl;
						}
					}
					int suma;
					suma = parc.returnMasina(car1) + parc.returnMasina(car2);
					cout << "Pentru cele doua masini alese anterior pretul total de inchiriere pentru o zi este: "<< suma <<"$"<<endl;
						
					optiuniOperatori = 0;
				}
				else {
					cout << "Optiune inexistenta! Alegeti alta optiune!" << endl;
					cin >> optiuniOperatori;
				}
			}


			optiune = 0;
			break;

		case 4:
			cout << "La revedere!" << endl;
			break;

		default:
			cout << "Optiune inexistenta! Alegeti alta optiune!" << endl;
			cin >> optiune;
			break;
		}
	}

}
